/******************************************************************************************************************
***		Importador de modelos de 3D Max a OpenGL - Version 3.1 - Version para Aplicaciones en Win32				***
***			Autor: Raymundo Espinosa Roque																		***
***			Estudiante de 4to semestre																			***
***			Licenciatura en Multimedia y Animación Digital 														***
***			Facultad de Ciencias Físico Matemáticas																***
***			Universidad Autónoma de Nuevo León																	***
***			13 de noviembre de 2012																			***
***																												***
***		Notas:																									***
***			VERSION 1.0 y VERSION 2.0-																			***
***			Para usar el importador el modelo de 3D Max debe cumplir ciertas condiciones:						***
***			*Todas las caras de los objetos deben de ser cuadradas, es decir, estar formadas por 4 vértices,	***
***			 de otra manera el programa marcará error.															***
***			*Todos los objetos deben de tener texturas: archivos de imagenes puestos sobre los objetos. No 		***
***			 las texturas que el 3D max proporciona.															***
***			*Todas las texturas, al momento de exportar el modelo a archivo .obj deben ser de dimensiones 		***
***			 iguales y de potencias de 2, por ejemplo 256*256, 512*512, etc. Entre mas pequeña sean las 		***
***			 dimensiones de las texturas mas rápido cargará el programa las texturas.							***
***																												***
***			DIFERENCIAS ENTRE VERSIONES																			***
***			*La organizacion de los datos del modelo que se carga del archivo .obj ahora se almacenan			***
***			 en un arreglo de estructuras.																		***
***																												***																									***
***			VERSION 3.0-																						***
***			*Se redefine el contenido de la estructura base que contiene la información de cada objeto.			***
***			 Se modifican las siguientes características:														***
***				-Se elimina el arreglo que contiene la toda la informacion (vertices, coordenadas de textura	***
***				 y normales) y se crean 3 arreglos separados para contener cada uno de los datos.				***
***				 El fin de lo anterior es hacer mas eficiente el programa.										***
***			*Se cambia el uso de caras cuadradas y triangulares a solo triangulares, esto para trabajar con		***
***			 el punto anterior.																					***
***			*Se corrigio la limitante de usar solo texturas, también puede tener colores solidos. Dicho color	***
***			 esta definido por el modelo creado en 3D Max														***
***			*Se incluyo la posibilidad de darle transparencia a los objetos aunque puede presentar ciertas		***
***			 anomalías o resultados distintos a como el modelo luce en 3D Max									***
***			VERSION 3.1 / Win32-																				***
***			*El importador genera 18 advertencias debido al uso de funciones para:								***
***				-Manejo de cadenas, conversion: strcpy, strcat y strtok.										***
***				-Conversión de datos WCHAR a char: mbstowc														***
***				-Conversión de char a int: itoa																	***
***			*Tiene que asegurarse de cumplir con ciertas condiciones de los nombres de los materiales y los		***
***			 nombres de las texturas:																			***
***				-Los nombres de los materiales que se usen en 3D Max deben ser máximo de 50 caracteres			***
***				-Los nombres de las texturas que se usen en 3D Max deben ser máximo de 40 caracteres			***
***			*Lo anterior es con el fin de garantizar estabilidad del programa al realizar la lectura de los		***
***			 archivos, ya que esta diseñado para leer un máximo de 100 caracteres por linea de cualquier archivo.***
*******************************************************************************************************************/
#include <ctime>		//libreria para manejar fechas
#include <fstream>		//libreria para manejar archivos
#include <time.h>
#include <gdiplus.h>	//libreria para manejar imagenes
#include <GL/gl.h>		//librerias para utilizar OpenGL
#include <GL/glu.h>
#include "Imagenes.h"
#include "ShaderDemo.h"
#include "glext.h"
using namespace std;
using namespace Gdiplus;
			
 class objLoaderRERWorld_v3_1_WIN32
{
public:
	//estructura base del importador, contiene variables para almacenar informacion de un objeto
	struct objectData
	{
		unsigned int totalFaces;	//almacena el total de caras del objeto
		unsigned int IDtexture;		//almacena un identificador para saber que textura le corresponde
		char* objectName;			//almacena el nombre del objeto (nombre que se le asigna en 3D Max)
		char* textureName;			//almacena el nombre de la textura que le corresponde (almacenado en el archivo .mtl)
		char *imageName;			//almacena el nombre del archivo de la textura
		float RGB[3];				//arreglo que guarda el color del objeto (componentes rojo,verde y azul)
		float Shininess;			//.....pendiente
		float Transparency;			//Almacena el valor de transparencia u opacidad del objeto
		float specularColor[3];		//Almacena el color especular del objeto(color del reflejo)...falta activarlo en OpenGL
		bool Texture;				//variable que se utiliza para validar si el objeto posee textura o no 
		unsigned int vertNumb;		//guarda el numero de vertices del objeto
		unsigned int normNumb;		//guarda el numero de normales del objeto
		unsigned int texcNumb;		//guarda el numero de coordenadas de textura del objeto
		float* sVertices;			//puntero que tiene la direccion inicial de el arreglo de los vertices ordenados del objeto
		float* sNormals;			//puntero que tiene la direccion inicial de el arreglo de las normales ordenadas del objeto
		float* sTextureCoords;		//puntero que tiene la direccion inicial de el arreglo de las coordenadas de textura ordenadas del objeto
	};
	unsigned int totalObjects;		//variable que almacena el total de objetos
	objectData* Objects;			//Puntero para crear un arreglo dinamico de la estructura objectData para almacenar todos los objetos del modelo
									//Este será el arreglo donde se almacenará toda la información de cada objeto
public:
	//Variables que contendran informacion del archivo .obj
	char*  fileName;				//Cadena que almacena el nombre de un archivo que sera manipulado
	char*  fullName;				//Cadena que almacena el nombre y extension de un archivo
	char fileString[100];			//Arreglo de caracteres que almacena la informacion de una linea dentro de un archivo
	char** Data;					//Cadenas que almacenaran varias cadenas separadas a partir de una 
	char** DataFaces;				//cadena mas grande
	float** Vertices;				//Arreglo bidimensional para almacenar todos los vertices (sus componentes en X, Y y Z) del modelo 
	float** Normals;				//Arreglo bidimensional para almacenar todas las normales (sus componentes en X, Y y Z) del modelo 
	float** TextureCoords;			//Arreglo bidimensional para almacenar todas las coordenadas de textura (sus componentes en U y V) del modelo 
	unsigned int totalVertices;		//Guarda la cantidad total de vertices del modelo importado
	unsigned int totalNormals;		//Guarda la cantidad total de normales del modelo importado
	unsigned int totalTextureCoords;//Guarda la cantidad total de coordenadas de textura del modelo importado
	//Variables que contendran informacion del archivo .mtl
	unsigned int mtl;				//Guarda la cantidad de materiales usados en el modelo
	unsigned int txtrs;				//Guarda la cantidad de texturas usadas en el modelo (Un material no es necesariamente una textura)
	float** RGB;					//Guarda el color de cada material (compentes rojor, verde y azul)
	float** Specular;				//Guarda los componentes del color especular de cada material
	float* Shininess;				//........pediente
	float* Opacity;					//Almacena el valor de transparencia u opacidad de cada material
	char*** TextureExistence;		//Almacena tanto el nombre como un identificador para hacer una relación entre que objetos tiene textura 
	GLuint *IDT;					//Identificador que sirve a OpenGL para hacer referencia a las texturas cargadas
	char** textureNames;			//Arreglo donde se guardan los nombres de las texturas 
	WCHAR** Textures;				//Arreglo que contendra los nombres de las texturas para despues ser cargadas en forma de BitMap

	int minO,hrO,ddO,mmO,yyyyO;
	int minR,hrR,ddR,mmR,yyyyR;
	int WithShader;//saber si usa shader
	ShaderDemo *gpuDemo;
protected:
	objLoaderRERWorld_v3_1_WIN32(){}
public:
	//Constructor de la clase: recibe como parametro el nombre del archivo
	objLoaderRERWorld_v3_1_WIN32(char* objFile,char* vertextShader ,char* fragmentShader)
	{
		cambio=false;
		fileName=objFile;			//asigna el nombre del archivo
		totalObjects=0;				//Se inicializan los contadores a cero
		totalVertices=0;
		totalNormals=0;
		totalTextureCoords=0;
		objLoadAllRERWorld_v3_1();	//se llama a la funcion que contiene llamadas a otras funciones
		WithShader=0;
		if(vertextShader!= 0 && fragmentShader!=0)
		{
			this->gpuDemo= new ShaderDemo(vertextShader,fragmentShader);
			gpuDemo->ligador(gpuDemo->vertShader, gpuDemo->fragShader);
			WithShader=1;
		}


	}

	//destructor de la clase: libera la memoria eliminando el arreglo principal de la clase
	~objLoaderRERWorld_v3_1_WIN32()
	{
		delete Objects;
	}
public:
	//Funcion que llama a cada rutina para cargar la informacion de los archivos
	void objLoadAllRERWorld_v3_1()
	{
		//loadDataModelFileRERWorld();
		getDataRERWorld();
		getObjDataToArraysRERWorld();
		getTotalObjectsInfoRERWorld();
		loadMtlFileRERWorld();
		//createDataModelFileRERWorld();
	}
public:
	bool load3DMaxObjFile()
	{
		char *obj3D,*objRER;
		char s1[100],s2[100];
		char **subS1, **subS2;
		char **subSubS1, **subSubS2;
		obj3D = new char[strlen(fileName)];
		objRER = new char[strlen(fileName)];
		strcpy(obj3D,fileName);
		strcpy(objRER,fileName);
		strcat(obj3D,".obj");
		strcat(objRER,".objRER");
		ifstream hfileOBJ3D(obj3D,ios::in);
		ifstream hfileOBJRE(objRER,ios::in);
		hfileOBJ3D.getline(s1,100);
		hfileOBJ3D.getline(s1,100);
		hfileOBJRE.getline(s2,100);
		hfileOBJRE.getline(s2,100);

		subS1=splitString(s1," ");
		subS2=splitString(s2," ");

		//subSubS1=splitString(subS1[]," ");
		//subSubS2=splitString(subS2[]," ");
		

		hfileOBJ3D.close();
		hfileOBJRE.close();
		delete obj3D;
		delete objRER;
	}
	//Funcion que modifica los contadores para utilizarlos en la creacion de arreglos dinamicos
	void getDataRERWorld()
	{
		fullName = new char[strlen(fileName)];	//se crea una cadena de tamaño del nombre del archivo	
		strcpy(fullName,fileName);				//se copia el nombre del archivo a donde se almacenara el nombre completo del archivo (con extension)
		strcat(fullName,".obj");				//se agrega la extension al nombre del archivo
		ifstream objData(fullName,ios::in);		//se crea un manejador para accesar al archivo
		while(!objData.eof())					//Ciclo que se repite mientras no se llegue al final del archivo
		{
			objData.getline(fileString,100);		//fileString contendrá el texto de una linea (máximo 100 caracteres) del archivo
			if(strstr(fileString,"object "))	//Se incrementa en una unidad cada contador
				totalObjects++;					//en caso de que la cadena fileString contenga 
			else if(strstr(fileString,"v "))	//la subcadena que se encuentra entre
				totalVertices++;				//las comillas dobles
			else if(strstr(fileString,"vn "))	
				totalNormals++;					
			else if(strstr(fileString,"vt "))	
				totalTextureCoords++;			
			
		}
		objData.close();						//Se cierra el proceso de lectura del archivo
		delete objData;							//Se elimina el manejador de acceso al archivo
	}

	//Funcion que crea los arreglos dinamicos y almacena la información tal como la encuentra en el archivo .obj
	void getObjDataToArraysRERWorld()
	{
		Vertices = new float*[totalVertices];				//se crea un arreglo dinamico de vertices de la cantidad total de vertices
		Normals =  new float*[totalNormals];				//se crea un arreglo dinamico de normales de la cantidad total de normales
		TextureCoords = new float*[totalTextureCoords];		//se crea un arreglo dinamico de coordenadas de texutra de la cantidad total de coordenadas de textura
		for(unsigned int v=0;v<totalVertices;v++)			//Se crean un arreglo de tres componentes para almacenar las componentes en X, Y y Z para
			Vertices[v] = new float[3];						//cada vertice,
		for(unsigned int n=0;n<totalNormals;n++)		
			Normals[n] = new float[3];						//cada normal y 
		for(unsigned int t=0;t<totalTextureCoords;t++)	
			TextureCoords[t] = new float[2];				//las coordenadas de textura unicamente almacenan dos compenentes: U y V
		Objects = new objectData[totalObjects];				//Se crea el arreglo de estructuras

		int vIndex=0,nIndex=0,tIndex=0,objIndex=0;			//Se declaran e inicializan los contadores a cero
		ifstream objDataStore(fullName,ios::in);			//Se crea un manejador para acceder nuevamente al archivo, esta vez para extraer la informacion
															//de los vertices, normales, coordenadas de textura, materiales y caras
		while(!objDataStore.eof())							//Ciclo que se ejecuta hasta que se llegue al final del archivo
		{
			objDataStore.getline(fileString,100);			//fileString contendra una linea de texto del archivo
			if(strstr(fileString,"v "))						//Si fileString contiene una "v " significa que esa linea contiene informacion
			{												//de un vertice del modelo. Por ejemplo: v 1.200 3.400 5.600
				Data=splitString(fileString," ");			//Separamos la cadena en 4 cadenas que se almacenan en la variable Data
				for(unsigned int i=0;i<3;i++)				//Se ejecutan 3 iteraciones para obtener cada una de las 3 compentes dentro de las cadenas
					Vertices[vIndex][i]=(float)atof(Data[i+1]);//Convierte la cadena a flotante y se almacena en el areglo
				vIndex++;									//Se incrementa el contador
			}
			else if(strstr(fileString,"vn "))
			{
				Data=splitString(fileString," ");
				for(unsigned int i=0;i<3;i++)
					Normals[nIndex][i]=(float)atof(Data[i+1]);
				nIndex++;
			}
			else if(strstr(fileString,"vt "))
			{
				Data=splitString(fileString," ");
				TextureCoords[tIndex][0]=(float)atof(Data[1]);
				TextureCoords[tIndex][1]=(float)atof(Data[2])*-1;
				tIndex++;
			}
			else if(strstr(fileString,"object "))
			{
				Data=splitString(fileString," ");
				Objects[objIndex].objectName = new char[strlen(Data[2])];
				strcpy(Objects[objIndex].objectName,Data[2]);
			}
			else if(strstr(fileString,"usemtl "))
			{
				Data=splitString(fileString," ");
				Objects[objIndex].textureName = new char [strlen(Data[1])];
				strcpy(Objects[objIndex].textureName,Data[1]);
			}
			else if(strstr(fileString," vertices"))
			{
				Data=splitString(fileString," ");
				Objects[objIndex].vertNumb=(int)atoi(Data[1]);
			}
			else if(strstr(fileString," vertex normals"))
			{
				Data=splitString(fileString," ");
				Objects[objIndex].normNumb=(int)atoi(Data[1]);
			}
			else if(strstr(fileString," texture coords"))
			{
				Data=splitString(fileString," ");
				Objects[objIndex].texcNumb=(int)atoi(Data[1]);
			}
			else if(strstr(fileString," faces"))
			{
				Data=splitString(fileString," ");
				Objects[objIndex].totalFaces=(int)atoi(Data[1]);
				objIndex++;
			}
		}
		objDataStore.close();
		delete Data;
		delete objDataStore;
	}

	void getTotalObjectsInfoRERWorld()
	{
		int obj=-1,vIndex=0,nIndex=0,tIndex=0,numberCoord=0;
		for(unsigned int i=0;i<totalObjects;i++)
		{
			Objects[i].sVertices = new float[Objects[i].totalFaces*9];
			Objects[i].sNormals = new float[Objects[i].totalFaces*9];
			Objects[i].sTextureCoords = new float[Objects[i].totalFaces*6];
			Objects[i].Texture=false;
		}
		ifstream objData(fullName, ios::in);
		while(!objData.eof())
		{
			objData.getline(fileString,100);
			if(strstr(fileString,"object "))
			{
				obj++;
				vIndex=0;
				nIndex=0;
				tIndex=0;
			}
			else if(strstr(fileString,"f "))
			{
				memcpy(fileString,&fileString[2],sizeof(fileString));
				Data=splitString(fileString," ");
				for(unsigned int i=0;i<3;i++)
				{
					DataFaces=splitString(Data[i],"/");
					for(unsigned int j=0;j<3;j++)
					{
						numberCoord=(int)atoi(DataFaces[j])-1;
						switch(j)
						{
							case 0:
								Objects[obj].sVertices[vIndex]=Vertices[numberCoord][0];
								Objects[obj].sVertices[vIndex+1]=Vertices[numberCoord][1];
								Objects[obj].sVertices[vIndex+2]=Vertices[numberCoord][2];
								vIndex+=3;
								break;
							case 1:
								Objects[obj].sTextureCoords[tIndex]=TextureCoords[numberCoord][0];
								Objects[obj].sTextureCoords[tIndex+1]=TextureCoords[numberCoord][1];
								tIndex+=2;
								break;
							case 2:
								Objects[obj].sNormals[nIndex]=Normals[numberCoord][0];
								Objects[obj].sNormals[nIndex+1]=Normals[numberCoord][1];
								Objects[obj].sNormals[nIndex+2]=Normals[numberCoord][2];
								nIndex+=3;
						}
					}
				}
			}
		}
		delete objData;
		delete Data;
		delete DataFaces;
	}

	bool cambio;
	void loadMtlFileRERWorld()
	{
		mtl=txtrs=0;
		fullName[strlen(fullName)-4]=0;
		strcat(fullName,".mtl");
		ifstream mtlData(fullName,ios::in);
		while(!mtlData.eof())
		{
			mtlData.getline(fileString,100);
			if(strstr(fileString,"newmtl"))
				mtl++;
			if(strstr(fileString,"map_Kd"))
				txtrs++;
		}
		mtlData.close();
		delete mtlData;
		delete mtlData;
		Textures = new WCHAR*[txtrs];
		textureNames = new char*[mtl];
		RGB = new float*[mtl];
		Specular = new float*[mtl];
		for(unsigned int k=0;k<mtl;k++)
		{
			RGB[k]=new float[3];
			Specular[k]=new float[3];
		}
		Opacity = new float[mtl];
		Shininess = new float[mtl];
		TextureExistence = new char**[txtrs];
		for(unsigned int z=0;z<txtrs;z++)
			TextureExistence[z] = new char*[3];
		char** path;
		mtl=-1;
		txtrs=-1;
		
		ifstream mtlDataText(fullName,ios::in);
		while(!mtlDataText.eof())
		{
			mtlDataText.getline(fileString,100);
			if(strstr(fileString,"newmtl"))
			{
				path=splitString(fileString," ");
				textureNames[++mtl]= new char[strlen(path[1])];
				strcpy(textureNames[mtl], path[1]);
			}
			else
			if(strstr(fileString,"\tKd "))
			{
				path=splitString(fileString," ");
				for(unsigned int k=0;k<3;k++)
					RGB[mtl][k] = (float)atof(path[k+1]);
			}
			if(strstr(fileString,"\tKs "))
			{
				path=splitString(fileString," ");
				for(unsigned int k=0;k<3;k++)
					Specular[mtl][k] = (float)atof(path[k+1]);
			}
			if(strstr(fileString,"\tNs "))
			{
				path=splitString(fileString," ");
				Shininess[mtl] = (float)atof(path[1]);
			}
			else
			if(strstr(fileString,"\td "))
			{
				path=splitString(fileString," ");
				Opacity[mtl] = (float)atof(path[1]);
			}
			else
			if(strstr(fileString,"map_Kd "))
			{
				cambio=true;
				memcpy(fileString,&fileString[8],sizeof(fileString));
				WCHAR fileStringWCHAR[]=L"                                                           ";
				mbstowcs(fileStringWCHAR,fileString,strlen(fileString));
				txtrs++;
				*(Textures+txtrs) = new WCHAR[strlen(fileString)];
				memcpy(Textures[txtrs],fileStringWCHAR,sizeof(WCHAR)*strlen(fileString));
				Textures[txtrs][strlen(fileString)]=0;
				TextureExistence[txtrs][0]=new char[strlen(textureNames[mtl])];
				strcpy(TextureExistence[txtrs][0], textureNames[mtl]);
				TextureExistence[txtrs][1]=new char[3];
				itoa((int)txtrs,TextureExistence[txtrs][1],10);
				TextureExistence[txtrs][2]=new char[strlen(fileString)];
				strcpy(TextureExistence[txtrs][2],fileString);
			}
		}
		if(!cambio)
			txtrs=0;
		else
			txtrs+=1;
		mtlDataText.close();
		delete mtlDataText;
		delete path;
		if(cambio)
			loadTextureRERWorld(txtrs);

		delete Vertices;
		delete Normals;
		delete TextureCoords;


		assignIDsToObjectsRERWorld();
	}
	void loadTextureRERWorld(int totalTextures)
	{
		GdiplusStartupInput gdiplusStartupInput;
		ULONG_PTR gdiplusToken;
        GdiplusStartup(&gdiplusToken, &gdiplusStartupInput, NULL);

		WCHAR** tempo;
		tempo=Textures;
		unsigned int **sizeWH,*totalBytes;
		Bitmap** images;
		images = new Bitmap*[totalTextures];
		sizeWH = new unsigned int*[totalTextures];
		totalBytes = new unsigned int[totalTextures];
		for(int n=0;n<totalTextures;n++,tempo++)
		{
			images[n]=new Bitmap(*tempo);
			sizeWH[n]=new unsigned int[2];
			sizeWH[n][0]=(*images[n]).GetWidth();
			sizeWH[n][1]=(*images[n]).GetHeight();
			totalBytes[n]=sizeWH[n][0]*sizeWH[n][1]*4;
		}
		unsigned char *texturePointer,*pixelArray,*firstPixel;
		glEnable(GL_TEXTURE_2D);
		IDT = new GLuint[totalTextures];
		glPixelStorei(GL_UNPACK_ALIGNMENT, 1);	
		glGenTextures(totalTextures,IDT);
		BitmapData* bitmapData= new BitmapData;
		for(int z=0;z<totalTextures;z++)
		{ 
			Rect rect(0, 0, sizeWH[z][0], sizeWH[z][1]);
			(*images[z]).LockBits(&rect, ImageLockModeRead, PixelFormat32bppARGB, bitmapData);
			firstPixel=(unsigned char*)bitmapData->Scan0;
			pixelArray = new unsigned char[totalBytes[z]];
			texturePointer=pixelArray;
		    for(unsigned int i=0;i<totalBytes[z];i+=4)
		    {
				pixelArray[i+3] = firstPixel[i+3];
				pixelArray[i+2] = firstPixel[i];
				pixelArray[i+1] = firstPixel[i+1];
				pixelArray[i] = firstPixel[i+2];
		    }
		    (*images[z]).UnlockBits(bitmapData);

			glBindTexture(GL_TEXTURE_2D, IDT[z]);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
			glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_WRAP_T, GL_REPEAT);
			gluBuild2DMipmaps(GL_TEXTURE_2D, 4,sizeWH[z][0],sizeWH[z][1],GL_RGBA, GL_UNSIGNED_BYTE, texturePointer);
			glTexEnvf(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_REPLACE);
			delete pixelArray;
		}
		GdiplusShutdown(gdiplusToken);
		glDisable(GL_TEXTURE_2D);
		delete bitmapData;
		delete sizeWH;
		texturePointer = NULL;
		delete texturePointer;
		delete Textures;
	}
	void assignIDsToObjectsRERWorld()
	{
		for(unsigned int i=0;i<totalObjects;i++)
		{
			Objects[i].imageName= new char[100];
			strcpy(Objects[i].imageName,"NO IMAGE");
			for(unsigned int j=0;j<=mtl;j++)
			{
				if(strcmp(Objects[i].textureName,textureNames[j])==0)
				{
					for(unsigned int t=0;t<txtrs && (t!=0 || cambio);t++)
					{
						if(strcmp(Objects[i].textureName,TextureExistence[t][0])==0)
						{
							Objects[i].Texture=true;
							Objects[i].IDtexture=(unsigned int)atoi(TextureExistence[t][1]);
							strcpy(Objects[i].imageName,TextureExistence[t][2]);
							break;
						}
					}
					Objects[i].Transparency=Opacity[j];
					Objects[i].Shininess= Shininess[j];
					for(int c=0;c<3;c++)
					{
						Objects[i].RGB[c]=RGB[j][c];
						Objects[i].specularColor[c]=Specular[j][c];
					}
					break;
				}
			}
		}
		delete textureNames;
		delete RGB;
		delete Opacity;
		delete Specular;
		if(cambio)
			delete TextureExistence;
	}

	void loadDataModelFileRERWorld()
	{
		fullName = new char[strlen(fileName)];
		strcpy(fullName,fileName);			
		strcat(fullName,".objRER");
		ifstream openFile(fullName,ios::in);
		for(int i=0;i<16;i++)
			openFile.getline(fileString,100);
		Data=splitString(fileString," ");
		totalObjects = (unsigned int)atoi(Data[1]);
		Objects = new objectData[totalObjects];
		openFile.getline(fileString,100);
		Data=splitString(fileString," ");
		totalVertices = (unsigned int)atoi(Data[1]);
		openFile.getline(fileString,100);
		Data=splitString(fileString," ");
		totalNormals = (unsigned int)atoi(Data[1]);
		openFile.getline(fileString,100);
		Data=splitString(fileString," ");
		totalTextureCoords = (unsigned int)atoi(Data[1]);

		Objects = new objectData[totalObjects];

		int contObj=0;
		while(!openFile.eof())
		{
			openFile.getline(fileString,100);
			Data=splitString(fileString," ");
			if(strstr(fileString,"objName "))
			{
				Objects[contObj].objectName = new char[strlen(fileString)];
				strcpy(Objects[contObj].objectName,Data[1]);
			}
			else
			if(strstr(fileString,"matName "))
			{
				Objects[contObj].textureName = new char[strlen(fileString)];
				strcpy(Objects[contObj].textureName,Data[1]);
			}
			else
			if(strstr(fileString,"texName "))
			{
				Objects[contObj].imageName = new char[strlen(fileString)];
				strcpy(Objects[contObj].imageName,Data[1]);
			}
			else
			if(strstr(fileString,"Texture "))
			{
				if(strcmp(Data[1],"1")==0)
					Objects[contObj].Texture = true;	
				else
					Objects[contObj].Texture = false;	
			}
			else
			if(strstr(fileString,"IDntext "))
				Objects[contObj].IDtexture =(unsigned int)atoi(Data[1]);
			else
			if(strstr(fileString,"facVN&T "))
			{
				Objects[contObj].sVertices = new float[(unsigned int)atoi(Data[1])];
				Objects[contObj].sNormals = new float[(unsigned int)atoi(Data[1])];
				Objects[contObj].sTextureCoords = new float[(unsigned int)atoi(Data[2])];
			/*}
			else
			if(strstr(fileString,"vnt_Num "))
			{*/
				Objects[contObj].vertNumb = (unsigned int)atoi(Data[1]);
				Objects[contObj].normNumb = (unsigned int)atoi(Data[1]);
				Objects[contObj].texcNumb = (unsigned int)atoi(Data[2]);				
			}
			else
			if(strstr(fileString,"Vertice "))
			{
				for(unsigned int vrf=0;vrf<Objects[contObj].vertNumb;vrf+=3)
				{
					openFile.getline(fileString,100);
					Data=splitString(fileString," ");
					Objects[contObj].sVertices[vrf]=(float)atof(Data[1]);
					Objects[contObj].sVertices[vrf+1]=(float)atof(Data[2]);
					Objects[contObj].sVertices[vrf+2]=(float)atof(Data[3]);
				}
			}
			else
			if(strstr(fileString,"Normals "))
			{
				for(unsigned int nrf=0;nrf<Objects[contObj].normNumb;nrf+=3)
				{
					openFile.getline(fileString,100);
					Data=splitString(fileString," ");
					Objects[contObj].sNormals[nrf]=(float)atof(Data[1]);
					Objects[contObj].sNormals[nrf+1]=(float)atof(Data[2]);
					Objects[contObj].sNormals[nrf+2]=(float)atof(Data[3]);
				}
			}
			else
			if(strstr(fileString,"TexCoor "))
			{
				for(unsigned int trf=0;trf<Objects[contObj].texcNumb;trf+=2)
				{
					openFile.getline(fileString,100);
					Data=splitString(fileString," ");
					Objects[contObj].sTextureCoords[trf]=(float)atof(Data[1]);
					Objects[contObj].sTextureCoords[trf+1]=(float)atof(Data[2]);
				}
			}
			else
			if(strstr(fileString,"RGB_Arr "))
			{
				Objects[contObj].RGB[0]=(float)atof(Data[1]);
				Objects[contObj].RGB[1]=(float)atof(Data[2]);
				Objects[contObj].RGB[2]=(float)atof(Data[3]);
			}
			else
			if(strstr(fileString,"Spec_ar "))
			{
				Objects[contObj].specularColor[0]=(float)atof(Data[1]);
				Objects[contObj].specularColor[1]=(float)atof(Data[2]);
				Objects[contObj].specularColor[2]=(float)atof(Data[3]);
			}
			else
			if(strstr(fileString,"ShinyAr "))
				Objects[contObj].Shininess=(float)atof(Data[1]);
			else
			if(strstr(fileString,"TranspF "))
				Objects[contObj++].Transparency=(float)atof(Data[1]);
		}
	}
	void createDataModelFileRERWorld()
	{
		fullName[strlen(fullName)-4]=0;
		strcat(fullName,".objRER");
		ofstream saveFile(fullName,ios::trunc);
		time_t now = time(0);
		tm *ltm = localtime(&now);
		saveFile<<"# "<<fullName<<" file - OBJ Exporter\n";
		saveFile<<"# File Created: "<<ltm->tm_mon<<"/"<<ltm->tm_mday<<"/"<<1900+ltm->tm_year<<" "<<ltm->tm_hour<<":"<<ltm->tm_min<<":"<<ltm->tm_sec<<"\n";
		saveFile<<"#     FORMAT FILE CREATED BY:                              \n";
		saveFile<<"#          RAYMUNDO ESPINOSA ROQUE                         \n"; 
		saveFile<<"#          UNIVERSIDAD AUTONOMA DE NUEVO LEON              \n";
		saveFile<<"#          FACULTAD DE CIENCIAS FISICO MATEMATICAS         \n";
		saveFile<<"#          LIC. EN MULTIMEDIA Y ANIMACION DIGITAL          \n";
		saveFile<<"#          4th semester student                            \n";
		saveFile<<"#          Version 1.0 - September/31/2012                 \n";
		saveFile<<"#   This file contains data from a model made on 3D max    \n";
		saveFile<<"#   and processed by the C++ class                         \n";
		saveFile<<"#   objLoaderRERWorld_v3_1_WIN32.                          \n";
		saveFile<<"#   Use this file with objLoaderRERWorld_v3_1_WIN32 class  \n";
		saveFile<<"#   to make a faster load of data of the 3D Max model.     \n\n";
		saveFile<<"totalObjects "<<totalObjects<<"\n";
		saveFile<<"totalVertces "<<totalVertices<<"\n";
		saveFile<<"totalTCoords "<<totalTextureCoords<<"\n\n";
		for(unsigned int i=0;i<totalObjects;i++)
		{
			saveFile<<"objName "<<Objects[i].objectName<<"\n";
			saveFile<<"matName "<<Objects[i].textureName<<"\n";
			saveFile<<"texName "<<Objects[i].imageName<<"\n";
			saveFile<<"Texture "<<Objects[i].Texture<<"\n";
			saveFile<<"IDntext "<<Objects[i].IDtexture<<"\n";
			saveFile<<"facVN&T "<<Objects[i].totalFaces*9<<" "<<Objects[i].totalFaces*6<<"\n";
			for(unsigned int vsf=0;vsf<Objects[i].totalFaces*9;vsf+=3)
				saveFile<<"Vertice "<<Objects[i].sVertices[vsf]<<" "<<Objects[i].sVertices[vsf+1]<<" "<<Objects[i].sVertices[vsf+2]<<"\n";
			for(unsigned int nsf=0;nsf<Objects[i].totalFaces*9;nsf+=3)
				saveFile<<"Normals "<<Objects[i].sNormals[nsf]<<" "<<Objects[i].sNormals[nsf+1]<<" "<<Objects[i].sNormals[nsf+2]<<"\n";
			for(unsigned int tsf=0;tsf<Objects[i].totalFaces*6;tsf+=2)
				saveFile<<"TexCoor "<<Objects[i].sTextureCoords[tsf]<<" "<<Objects[i].sTextureCoords[tsf+1]<<"\n";
			saveFile<<"RGB_Arr "<<Objects[i].RGB[0]<<" "<<Objects[i].RGB[1]<<" "<<Objects[i].RGB[2]<<"\n";
			saveFile<<"Spec_ar "<<Objects[i].specularColor[0]<<" "<<Objects[i].specularColor[1]<<" "<<Objects[i].specularColor[2]<<"\n";
			saveFile<<"ShinyAr "<<Objects[i].Shininess<<"\n";
			saveFile<<"TranspF "<<Objects[i].Transparency<<"\n\n";
		}	
		saveFile.close();
		triangulon=0;
	}
	
	public:
	void RenderRERWorld()
	{
		
		//glClearColor(0, 0, 0, 0) ;
		//glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		glEnableClientState(GL_TEXTURE_COORD_ARRAY);
		glEnableClientState(GL_NORMAL_ARRAY);       
		glEnableClientState(GL_VERTEX_ARRAY); 
		if(WithShader==1)
		{
			gpuDemo->use();
		}
		for(unsigned int object=0;object<totalObjects;object++)
		{
			glEnable(GL_BLEND);
			glEnable(GL_TEXTURE_2D);
			glDepthMask(GL_TRUE);
			if(Objects[object].Texture)
			{
				glBindTexture(GL_TEXTURE_2D,IDT[Objects[object].IDtexture]);
				if(Objects[object].Transparency<1)
					glBlendFunc(GL_SRC_ALPHA,GL_ONE);
			}
			else
			{
				glDisable(GL_TEXTURE_2D);
				glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
			}
			glColor4f(Objects[object].RGB[0],Objects[object].RGB[1],Objects[object].RGB[2],Objects[object].Transparency);
		      
			glVertexPointer(3, GL_FLOAT,0,Objects[object].sVertices);
			glNormalPointer(GL_FLOAT,0,Objects[object].sNormals);
			glTexCoordPointer(2, GL_FLOAT,0,Objects[object].sTextureCoords);
			glDrawArrays(GL_TRIANGLES,0,Objects[object].totalFaces*3);
			glDisable(GL_TEXTURE_2D);
			glDisable(GL_BLEND);
		}		
		glDisableClientState(GL_TEXTURE_COORD_ARRAY);
		glDisableClientState(GL_NORMAL_ARRAY);
		glDisableClientState(GL_VERTEX_ARRAY);
		if(WithShader==1){	gpuDemo->desuse();}
	}

	public:
		int triangulon;
	
	char** splitString(char src[],char separator[])
	{
		char **newStrings,*aux;
		char tempo[100];
		strcpy(tempo,src);

		int i=0,j=0;

		aux = strtok (src,separator);
		while (aux != NULL)
		{
			aux = strtok (NULL,separator);
			i++;
		}
		newStrings = new char*[i];
		strcpy(src,tempo);
		aux = strtok (src,separator);
		while (aux != NULL)
		{
			newStrings[j++] = new char[strlen(aux)];
			aux = strtok (NULL,separator);
		}
		strcpy(src,tempo);
		aux = strtok (src,separator);
		j=0;
		while (aux != NULL)
		{
			*(newStrings+j) = aux;
			j++;
			aux = strtok (NULL,separator);
		}
		return newStrings;

	}

};
