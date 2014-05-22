#include<iostream>
#include<fstream>
#include <vector>
#include <gl/gl.h>
#include <gl/glu.h>
#include "glext.h"
#include <gl/glut.h>
#include "Imagenes.h"

using namespace std;

class importar
{
public:
unsigned int skyDome;
WCHAR *nombre;
fstream leer, poligonos;
char lectura[25], uni_1[17], uni_2[17], uni_3[17];
float a_puntos, a_textura, a_normales;
int a_uniones;
bool banderilla, banderita, carga;



vector<float> puntos[3];//v
vector<float> textura[2];//vt
vector<GLfloat> normales[3];//vn
vector<int> uniones[13];//f
vector<float> puntosCT[3];
vector<float> puntosCT1[3];
vector<float> puntosCT2[3];
bool traslacionnave;

	importar ()
	{
		traslacionnave=true;
		carga=false;
		banderilla=false;
		puntos[0].push_back(0);
		puntos[1].push_back(0);
		puntos[2].push_back(0);
		textura[0].push_back(0);
		textura[1].push_back(0);
		normales[0].push_back(0);
		normales[1].push_back(0);
		normales[2].push_back(0);
		uniones[0].push_back(0);
		uniones[1].push_back(0);
		uniones[2].push_back(0);
		uniones[3].push_back(0);
		uniones[4].push_back(0);
		uniones[5].push_back(0);
		uniones[6].push_back(0);
		uniones[7].push_back(0);
		uniones[8].push_back(0);
		uniones[9].push_back(0);
		uniones[10].push_back(0);
		uniones[11].push_back(0);
		uniones[12].push_back(0);
		puntosCT[0].push_back(0);
		puntosCT[1].push_back(0);
		puntosCT[2].push_back(0);
		puntosCT1[0].push_back(0);
		puntosCT1[1].push_back(0);
		puntosCT1[2].push_back(0);
		puntosCT2[0].push_back(0);
		puntosCT2[1].push_back(0);
		puntosCT2[2].push_back(0);

		banderita=false;
	}

	void lee_obj(char obj[])
	{
		if(carga==false)
		{
		poligonos.open("poligonos.txt",ios::out);
		poligonos.close();
		poligonos.clear();
		leer.open(obj, ios::in);
		poligonos.open("poligonos.txt",ios::app);
		
			do
			{
				leer>>lectura;
					if(banderilla==true)
					{
						for(int u=0;u<25;u++)
						{
							if(lectura[u]=='/')
							{
							lectura[u]=' ';
							banderita=true;
							}
						}
						if(banderita==true)//es de 4 puntos
							{
							banderita=false;
							poligonos<<"0 "<<uni_1<<" "<<uni_2<<" "<<uni_3<<" "<<lectura<<"\n";
							}
							else//es de 3 puntos
							{
							poligonos<<"1 "<<uni_1<<" "<<uni_2<<" "<<uni_3<<"\n";
							banderita=false;
							}
						banderilla=false;
					}

				if(lectura[0]=='v'&&lectura[1]==NULL)//es un punto
					{
					leer>>a_puntos;
					puntos[0].push_back(a_puntos);
					puntosCT[0].push_back(a_puntos);
					puntosCT1[0].push_back(a_puntos);
					puntosCT2[0].push_back(a_puntos);
					leer>>a_puntos;
					puntos[1].push_back(a_puntos);
					puntosCT[1].push_back(a_puntos);
					puntosCT1[1].push_back(a_puntos);
					puntosCT2[1].push_back(a_puntos);
					leer>>a_puntos;
					puntos[2].push_back(a_puntos);
					puntosCT[2].push_back(a_puntos);
					puntosCT1[2].push_back(a_puntos);
					puntosCT2[2].push_back(a_puntos);
					}

				if(lectura[0]=='v'&&lectura[1]=='t')//es una textura
					{
					leer>>a_textura;
					textura[0].push_back(a_textura);
					leer>>a_textura;
					textura[1].push_back(a_textura);
					}

				if(lectura[0]=='v'&&lectura[1]=='n')//es un normal
					{
					leer>>a_normales;
					normales[0].push_back(a_normales);
					leer>>a_normales;
					normales[1].push_back(a_normales);
					leer>>a_normales;
					normales[2].push_back(a_normales);
					}

				if(lectura[0]=='f'&&lectura[1]==NULL)
					{
					leer>>uni_1;
						for(int u=0;u<17;u++)
						{if(uni_1[u]=='/')
						{uni_1[u]=' ';}}
					leer>>uni_2;
						for(int u=0;u<17;u++)
						{if(uni_2[u]=='/')
						{uni_2[u]=' ';}}
					leer>>uni_3;
						for(int u=0;u<17;u++)
						{if(uni_3[u]=='/')
						{uni_3[u]=' ';}}
					banderilla=true;
					}

				for(int u=0;u<25;u++)
					{lectura[u]=NULL;}
				
			}while(leer!=NULL);
		leer.close();
		leer.clear();
		poligonos.close();
		poligonos.clear();

		poligonos.open("poligonos.txt",ios::in);
		while(poligonos!=NULL){
			poligonos>>a_uniones;
			uniones[0].push_back(a_uniones);
				if(a_uniones==0)//4 puntos
				{
				poligonos>>a_uniones;
				uniones[1].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[2].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[3].push_back(a_uniones);

				poligonos>>a_uniones;
				uniones[4].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[5].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[6].push_back(a_uniones);

				poligonos>>a_uniones;
				uniones[7].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[8].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[9].push_back(a_uniones);

				poligonos>>a_uniones;
				uniones[10].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[11].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[12].push_back(a_uniones);
				}
				else//3 puntos
				{
				poligonos>>a_uniones;
				uniones[1].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[2].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[3].push_back(a_uniones);

				poligonos>>a_uniones;
				uniones[4].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[5].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[6].push_back(a_uniones);

				poligonos>>a_uniones;
				uniones[7].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[8].push_back(a_uniones);
				poligonos>>a_uniones;
				uniones[9].push_back(a_uniones);

				uniones[10].push_back(0);
				uniones[11].push_back(0);
				uniones[12].push_back(0);
				}

		}
		poligonos.close();
		poligonos.clear();
		carga=true;
		}
	}

	void cargartextura(WCHAR *tex)
	{
		if(carga==false)
		{
		nombre=tex;
		Imagenes texturas;			
						
				texturas.Carga(nombre);		
				glGenTextures(1, &skyDome);
				glBindTexture(GL_TEXTURE_2D, skyDome);
				glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_WRAP_S,GL_REPEAT);
					glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_WRAP_T,GL_REPEAT);
					glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MAG_FILTER,GL_NEAREST);
					glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MIN_FILTER,GL_NEAREST);
				gluBuild2DMipmaps(GL_TEXTURE_2D, GL_RGBA, texturas.Ancho(), texturas.Alto(), GL_RGBA, GL_UNSIGNED_BYTE, texturas.Dir_Imagen());
				texturas.Descarga();
		}
	}

	void dibujar()
	{
	int n=1;
	glEnable(GL_TEXTURE_2D);
	glTexEnvf(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE);
	glBindTexture(GL_TEXTURE_2D, skyDome);		

	glEnable(GL_CULL_FACE);
	while(n<((uniones[5].size())-1))
			{
				
			if(uniones[0][n]==1)
			{
				glPushMatrix();
					glBegin(GL_POLYGON);
						glNormal3f(normales[0][uniones[3][n]],normales[1][uniones[3][n]],normales[2][uniones[3][n]]);
						glTexCoord2f(textura[0][(uniones[2][n])], textura[1][(uniones[2][n])]);
						glVertex3f(puntos[0][uniones[1][n]],puntos[1][uniones[1][n]],puntos[2][uniones[1][n]]);

						glNormal3f(normales[0][uniones[6][n]],normales[1][uniones[6][n]],normales[2][uniones[6][n]]);
						glTexCoord2f(textura[0][(uniones[5][n])], textura[1][(uniones[5][n])]);
						glVertex3f(puntos[0][uniones[4][n]],puntos[1][uniones[4][n]],puntos[2][uniones[4][n]]);

						glNormal3f(normales[0][uniones[9][n]],normales[1][uniones[9][n]],normales[2][uniones[9][n]]);
						glTexCoord2f(textura[0][(uniones[8][n])], textura[1][(uniones[8][n])]);
						glVertex3f(puntos[0][uniones[7][n]],puntos[1][uniones[7][n]],puntos[2][uniones[7][n]]);
					glEnd();
				glPopMatrix();
			}
			else
			{
				glPushMatrix();
					glBegin(GL_POLYGON);
						glNormal3f(normales[0][uniones[3][n]],normales[1][uniones[3][n]],normales[2][uniones[3][n]]);
						glTexCoord2f(textura[0][(uniones[2][n])], textura[1][(uniones[2][n])]);
						glVertex3f(puntos[0][uniones[1][n]],puntos[1][uniones[1][n]],puntos[2][uniones[1][n]]);

						glNormal3f(normales[0][uniones[6][n]],normales[1][uniones[6][n]],normales[2][uniones[6][n]]);
						glTexCoord2f(textura[0][(uniones[5][n])], textura[1][(uniones[5][n])]);
						glVertex3f(puntos[0][uniones[4][n]],puntos[1][uniones[4][n]],puntos[2][uniones[4][n]]);

						glNormal3f(normales[0][uniones[9][n]],normales[1][uniones[9][n]],normales[2][uniones[9][n]]);
						glTexCoord2f(textura[0][(uniones[8][n])], textura[1][(uniones[8][n])]);
						glVertex3f(puntos[0][uniones[7][n]],puntos[1][uniones[7][n]],puntos[2][uniones[7][n]]);

						glNormal3f(normales[0][uniones[12][n]],normales[1][uniones[12][n]],normales[2][uniones[12][n]]);
						glTexCoord2f(textura[0][(uniones[11][n])], textura[1][(uniones[11][n])]);
						glVertex3f(puntos[0][uniones[10][n]],puntos[1][uniones[10][n]],puntos[2][uniones[10][n]]);
					glEnd();
				glPopMatrix();
			}
			n++;
			}
	glDisable(GL_TEXTURE_2D);
	glDisable(GL_CULL_FACE );
	
	}



	void tranformaciones(float x, float y, float z, float Trasx, float Trasy, float Trasz, float Ex, float Ey, float Ez)//aqui es donde estan todas las matrices
	{
		//rotacion------------>
			//rotar en el eje z
			int n=1;
			while(n<puntos[1].size())
			{
			puntosCT1[0][n]=((puntosCT[0][n]*(cos((0.017453277)*z)))-(puntosCT[1][n]*(sin((0.017453277)*z))));
			puntosCT1[1][n]=((puntosCT[0][n]*(sin((0.017453277)*z)))+(puntosCT[1][n]*(cos((0.017453277)*z))));
			puntosCT1[2][n]=puntosCT[2][n];
			n++;
			}
			//rotar en el eje y
			n=1;
			while(n<puntos[1].size())
			{
			puntosCT2[2][n]=((puntosCT1[2][n]*(cos((0.017453277)*y)))-(puntosCT1[0][n]*(sin((0.017453277)*y))));
			puntosCT2[0][n]=((puntosCT1[2][n]*(sin((0.017453277)*y)))+(puntosCT1[0][n]*(cos((0.017453277)*y))));
			puntosCT2[1][n]=puntosCT1[1][n];
			n++;
			}
			//rotar en el eje x
			n=1;
			while(n<puntos[1].size())
			{
			puntos[1][n]=((puntosCT2[1][n]*(cos((0.017453277)*x)))-(puntosCT2[2][n]*(sin((0.017453277)*x))));
			puntos[2][n]=((puntosCT2[1][n]*(sin((0.017453277)*x)))+(puntosCT2[2][n]*(cos((0.017453277)*x))));
			puntos[0][n]=puntosCT2[0][n];
			n++;
			}
		//rotacion------------>

		//escalamiento-------------->
		n=1;
		while(n<puntos[1].size())
		{
		puntos[0][n]=puntos[0][n]*Ex;
		puntos[1][n]=puntos[1][n]*Ey;
		puntos[2][n]=puntos[2][n]*Ez;
		n++;
		}	
		//escalamiento-------------->

		//translación---------->
		n=1;
		while(n<puntos[1].size())
		{
		puntos[0][n]=puntos[0][n]+Trasx;
		puntos[1][n]=puntos[1][n]+Trasy;
		puntos[2][n]=puntos[2][n]+Trasz;
		n++;
		}
		//translación---------->
	}


	void importador_obj(WCHAR *texturita, char obj[])
	{
	cargartextura(texturita);
	lee_obj(obj);
	dibujar();
	}

	~importar ()
	{
	
	}
};