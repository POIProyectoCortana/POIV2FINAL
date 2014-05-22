/////////////////////////////////////////////////////////////////////////
//Programa tutorial hecho por Rafael Rosas para los impresionantes LMADs
//en la busqueda de la clase mundial en el desarrollo de programadores
//de alto poder logico. Simplemente Amazing. 
//Version 6. 27 de Marzo de 2013
//
//Esta version solo muestra como se puede crear un programa de rango 3/4
//que explica parametros del win32 para crear una ventana, terreno, billboard
//skydome, game pad
////////////////////////////////////////////////////////////////////////

// es la cabecera basica para un programa de windows
#include <windows.h>
#include <windowsx.h>
#include <gl\glew.h>
#include <gl\GLU.h>
#include <gl\GL.h>
#pragma comment (lib, "glew32.lib") 
//Creamos una clase que administre por separado al OpenGL
//como fuera del lazo de windows
#include "GraphicsRR.h"
#include "GamePadRR.h"

#define Timer1 100

LRESULT CALLBACK WindowProc(HWND hWnd, 	UINT message, WPARAM wParam, LPARAM lParam);
void SetUpPixelFormat(HDC hDC);

//debemos declarar una variable global que maneje el acceso al dispositivo grafico
HDC gHDC;

//Declaramos al puntero del objeto 
GraphRR *OGLobj;
GamePadRR *gamPad;
bool renderiza=false;
float giro=0;
float pos_fwr;
float por_back;

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,  LPSTR lpCmdLine, int nCmdShow)
{  	   
	HWND hWnd;   
	
	WNDCLASSEX wc;    
	
	ZeroMemory(&wc, sizeof(WNDCLASSEX));    
	wc.cbSize = sizeof(WNDCLASSEX);  
	wc.style = CS_HREDRAW | CS_VREDRAW; 	
	wc.lpfnWndProc = WindowProc; 	
	wc.hInstance = hInstance;   	
	wc.hCursor = LoadCursor(NULL, IDC_ARROW); 	
	wc.hbrBackground = (HBRUSH)COLOR_WINDOW;	
	wc.lpszClassName = L"EjemploLMAD"; 	
	RegisterClassEx(&wc);     
	RECT wr = {0, 0, 800, 600};    
	AdjustWindowRect(&wr, WS_OVERLAPPEDWINDOW, FALSE);    

	hWnd = CreateWindowEx(NULL,  
		L"EjemploLMAD",                       
		L"Programa de win32 tutorial",             
		WS_OVERLAPPEDWINDOW,                            
		100,                     
		100,                     
		wr.right - wr.left,                        
		wr.bottom - wr.top,                   
		NULL,                     
		NULL,                
		hInstance,                        
		NULL);   	
	   
	ShowWindow(hWnd, nCmdShow);  
	glewInit();

	if (GLEW_ARB_vertex_shader && GLEW_ARB_fragment_shader)
	{
		//nada, todo bien
	}
	else {
		//mensaje que no se pudo correr el shader
		exit(1);
	}

	//Creamos al objeto y se lo pasamos al puntero
	OGLobj = new GraphRR(hWnd);
	gamPad = new GamePadRR(1);

	SetTimer(hWnd,Timer1,30,NULL);

	MSG msg = {0};     
	PlaySound(TEXT("SeaWaves.wav"), NULL, SND_FILENAME | SND_LOOP | SND_ASYNC);
		//SeaWaves.wav
	while(TRUE)   
	{      		
		if(PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))       
		{			    
			TranslateMessage(&msg); 		   
			DispatchMessage(&msg);           
			     
			if(msg.message == WM_QUIT)              
				break;        
		}        
		else       
		{   	
			//en este lazo estara ejecutandose el render
			//"renderiza" controla si se hace el render o no a traves
			//del timer Timer1
			if (renderiza)
			{

				if(gamPad->IsConnected())
				{
					//convierto a flotante el valor analogico de tipo entero
					float grados= (float)gamPad->GetState().Gamepad.sThumbLX/32767.0;
					//debido a que los controles se aguadean con el uso entonces ya no dan el cero
					//en el centro, por eso lo comparo con una ventana de aguadencia de mi control
					if (grados>0.19 || grados <-0.19)
						OGLobj->CamaraGiraY(grados*3.0);	

					float velocidad= (float)gamPad->GetState().Gamepad.sThumbLY/32767;
					if (velocidad>0.19 || velocidad <-0.19)
						OGLobj->CamaraAvanza(velocidad);	
				}
				else
				{
					//aqui ponemos un messgaebox para decir que se perdio la conexion con el gamepad
				}
				OGLobj->CamaraGiraY(giro);
				OGLobj->CamaraAvanza(pos_fwr);
				OGLobj->Render(gHDC);    
				renderiza=false;
			}
		}    
	}    
	
	return msg.wParam;
}

LRESULT CALLBACK WindowProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{   
	static HGLRC hRC;
	static HDC hDC;
	int ancho, alto;
	 
	switch(message)    
	{    
		//---------------------------------------------------------------------------------------
		//manejo provisional de la camara sin gamepad
	
	case WM_KEYDOWN:
		switch(lParam)
		{
			case 22020097://DOWN
				pos_fwr-=1;
				break;
			case 21495809://UP
				pos_fwr+=1;
				break;
			case 21692417://LEFT
				giro-=1.5;
				break;
			case 21823489://RIGTH
				giro+=1.5;
				break;
			case 1114113://W
				break;
			case 1966081://A
				break;
			case 2031617://S
				break;
			case 2097153://D
				break;
		}
		//GetKeyNameText(lParam, cad, 64);
		break;
		case WM_KEYUP:
			giro=0;
			pos_fwr=0;
			break;
		
		//fin del manejo provisional de la camara sin gmpad


		//---------------------------------------------------------------------------------------
		//este case se ejecuta cuando se crea la ventana, aqui asociamos al 
		//opengl con el dispositivo
	case WM_CREATE:
		hDC=GetDC(hWnd);
		gHDC=hDC;
		SetUpPixelFormat(hDC);
		hRC=wglCreateContext(hDC);
		wglMakeCurrent(hDC,hRC);
		break;
	
	case WM_TIMER:
		//OGLobj->angulo+=1.5;
		renderiza=true;
		break;
	case WM_DESTROY:           
		{  
			KillTimer(hWnd,Timer1);
			//en caso de salir desocupar los recursos del opengl
			wglMakeCurrent(hDC,NULL);
			wglDeleteContext(hRC);
			PostQuitMessage(0);  
			return 0;            
		} break;   

	case WM_SIZE:
		{
			//esta opcion del switch se ejecuta una sola vez al arrancar y si se
			//afecta el tamaño de la misma se dispara de nuevo
			alto = HIWORD(lParam);
			ancho= LOWORD(lParam);
			if (alto==0)
				alto=1;
			glViewport(0,0,ancho,alto);
			glMatrixMode(GL_PROJECTION);
			glLoadIdentity();
			gluPerspective(45.0f, (GLfloat)ancho/(GLfloat)alto,1.0f,10000.0f);
			glMatrixMode(GL_MODELVIEW);
			glLoadIdentity();
		}
		break;
	} 

	return DefWindowProc (hWnd, message, wParam, lParam);
}

void SetUpPixelFormat(HDC hDC)
{
	int PixForm;

	static PIXELFORMATDESCRIPTOR pixfordes = {
		sizeof(PIXELFORMATDESCRIPTOR), //tamaño de la estructura
		1, //numero de version
		PFD_DRAW_TO_WINDOW|PFD_SUPPORT_OPENGL|PFD_DOUBLEBUFFER, //soporta la ventana, el opengl y manejara doble buffer
		PFD_TYPE_RGBA, //formato de 32 bits rgba
		32, //tamaño del color en 32 bits
		0,0,0,0,0,0, //bits de color, no se usan
		0, //no hay buffer para el alfa
		0, //ignore el bit de corrimiento
		0, //no hay buffer de acumulacion
		0,0,0,0, //no hay bits de acumulacion
		16, //tamaño del flotante para el buffer z
		0, //no hay buffers de stencil
		0, //no hay buffers auxiliares
		PFD_MAIN_PLANE, //plano principal para dibujo
		0, //reservado
		0,0,0 //mascaras de capas ignoradas
	};

	PixForm=ChoosePixelFormat(hDC, &pixfordes);
	SetPixelFormat(hDC, PixForm, &pixfordes);
}