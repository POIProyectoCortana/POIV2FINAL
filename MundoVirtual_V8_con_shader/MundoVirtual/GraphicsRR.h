#ifndef _GRR
#define _GRR

#include <windows.h>
#include <windowsx.h>
#include <gl\GLU.h>
#include <gl\GL.h>
#include "glext.h"
#include "SkyDome.h"
#include "Terreno.h"
#include "VectorRR.h"
#include "Billboard.h"
#include "objLoaderRERWorld_v3_1_WIN32.h"

class Camara: public VectorRR
{
public:
	VectorRR posc, dirc;
	//importar nave;
	Camara()
	{
	}	

	void CamaraUpdate()
	{
		gluLookAt(posc.X, posc.Y, posc.Z,
			posc.X + dirc.X, posc.Y + dirc.Y, posc.Z + dirc.Z, 
			0, 1, 0);
	}

	void CamaraAvanza(float vel)
	{
		//cambie una multiplicacion por una suma
		posc.X = posc.X +  dirc.X * vel;
		posc.Y = posc.Y +  dirc.Y * vel;
		posc.Z = posc.Z +  dirc.Z * vel;

		gluLookAt(posc.X, posc.Y, posc.Z,
			posc.X + dirc.X, posc.Y, posc.Z + dirc.Z, 
			0, 1, 0);
	}

	void CamaraGiraY(float grados)
	{
		Transforma(dirc, grados, Ejes::EjeY);
	}
};

class GraphRR: public Camara
{
public:

	//importar nave;
	objLoaderRERWorld_v3_1_WIN32 *alaDelta;
	objLoaderRERWorld_v3_1_WIN32 *cubo;
	objLoaderRERWorld_v3_1_WIN32 *swampHouse;
	objLoaderRERWorld_v3_1_WIN32 *water;
	objLoaderRERWorld_v3_1_WIN32 *chair1;
	objLoaderRERWorld_v3_1_WIN32 *haus;
	objLoaderRERWorld_v3_1_WIN32 *ship;
	
	SkyDome *sky;
	Terreno *terreno;
	Billboard *billBoard[10];	
	float gira;
	float graditos;
	float angulo;
	float poscX, poscY, poscZ;
	float girar;
	float avanzar;

	GraphRR(HWND hWnd)
	{
		girar=0, avanzar=0;
		graditos=0;
		poscX=0, poscY=0, poscZ=0;
		posc=VectorRR(0, 13, 10);
		dirc=VectorRR(0, 0, -1);
		float matAmbient[] = {1,1,1,1};		
		angulo=0;
		
		glShadeModel(GL_SMOOTH);
		//habilitamos el control de profundidad en el render
		glEnable(GL_DEPTH_TEST);
		//habilitamos la iluminacion
		glEnable(GL_LIGHTING);
		/*glMaterialfv(GL_FRONT, GL_AMBIENT, matAmbient);		*/
		glEnable(GL_NORMALIZE);

		// habilitamos la luz 0 o primer luz
		glEnable(GL_LIGHT0);
		//habilitamos la forma de reflejar la luz
		glEnable(GL_COLOR_MATERIAL);		
		glEnable(GL_NORMALIZE);
		//glLightModeli(GL_LIGHT_MODEL_COLOR_CONTROL, GL_SEPARATE_SPECULAR_COLOR);
		//creamos el objeto skydome
		sky = new SkyDome(hWnd, 32,32,20, L"earth.jpg");		
		terreno = new Terreno(hWnd, L"terreno.jpg", L"texterr2.jpg", 400, 400, L"sand.png", L"zacatito.jpg");
		//cubo= new objLoaderRERWorld_v3_1_WIN32("SwampHouse");
		//alaDelta= new objLoaderRERWorld_v3_1_WIN32("AlaDelta");
	chair1= new objLoaderRERWorld_v3_1_WIN32("chair1",0,0);
		swampHouse= new objLoaderRERWorld_v3_1_WIN32("SwampHouse",0,0);
	    water= new objLoaderRERWorld_v3_1_WIN32("Water","water.vs","water.fs");
		
		inicializaBillboards(billBoard, hWnd);	
	}

	void inicializaBillboards(Billboard *bills[], HWND hWnd)
	{
		float ye=terreno->Superficie(0,0);
		bills[0] = new Billboard(hWnd, L"coral1.jpg", 6, 6, 0,ye-1,0);

		ye=terreno->Superficie(5,-5);
		bills[1] = new Billboard(hWnd, L"coral2.jpg", 6, 6, 5,ye-1,-5);

		ye=terreno->Superficie(-9,-15);
		bills[2] = new Billboard(hWnd, L"coral3.jpg", 8, 8, -9,ye-1,-15);
	}

	//el metodo render toma el dispositivo sobre el cual va a dibujar
	//y hace su tarea ya conocida
	void Render(HDC hDC)
	{
		//borramos el biffer de color y el z para el control de profundidad a la 
		//hora del render a nivel pixel.
		glClear(GL_COLOR_BUFFER_BIT|GL_DEPTH_BUFFER_BIT);
		glClearColor(0,0,0,0);
		glLoadIdentity();
		posc.Y = terreno->Superficie(posc.X, posc.Z) + 3;	
		CamaraUpdate();

	/*	glPushMatrix();
			cubo->RenderRERWorld();
			alaDelta->RenderRERWorld();
		glPopMatrix();*/


		GLfloat LightAmb2[] = { 1, 1, 1, 1.0 };
		glLightfv(GL_LIGHT0, GL_AMBIENT, LightAmb2);
		glPushMatrix();	
		//water->RenderRERWorld();
		glPopMatrix();
		glPushMatrix();		
		glTranslatef(posc.X, posc.Y - 5, posc.Z);		
		//decimos que dibuje la media esfera
		sky->Draw();		
		glPopMatrix();

		LightAmb2[0] = 0.2; LightAmb2[1] = 0.2; LightAmb2[2] = 0.2; LightAmb2[3] = 0.0;
		glLightfv(GL_LIGHT0, GL_AMBIENT, LightAmb2);
		//posicion de la luz, afecta al shader
		GLfloat LightPos[] = {60.0, 50.0,10.0, 1.0 };	  
	    glLightfv(GL_LIGHT0, GL_POSITION, LightPos);

		glPushMatrix();	
		terreno->Draw();	
		glPopMatrix();
		chair1->RenderRERWorld();				
		swampHouse->RenderRERWorld();	
		water->RenderRERWorld();
		
		
		//billBoard[0]->Draw(posc);//Central
		//billBoard[1]->Draw(posc);//derecha
		//billBoard[2]->Draw(posc);//izquierda
		SwapBuffers(hDC);
	}
};

#endif 