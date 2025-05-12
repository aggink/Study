#pragma once

#include <Windows.h>
#include <atomic>

#include "Event.h"

struct Message
{
	UINT message;
	WPARAM wParam;
	LPARAM lParam;
};



void setHwnd(HWND window);

void add_message(Message msg);

void start_gl_thread();
void start_msg_thread();

void join_render_thread();
void join_msg_thread();

void stop_all_threads();


struct MouseWheelEventArg
{
	float value;
};

struct MouseEventArg
{
	short x;
	short y;
};

struct KeyEventArg
{
	int key;
};

class OpenGL
{
	
	HDC g_hDC;
	HGLRC g_hRC;

	std::atomic_int tmp_width, tmp_height;
	
	std::atomic_bool drag = false;
	double camDist;
	double camX, camY, camZ;
	double camNz;
	double fi1, fi2;

	int mouseX, mouseY;

	std::atomic_bool resize_pending;

	std::mutex events_mutex;
	std::list<std::function<void(void)>> events_for_render;
	HWND g_hWnd;
	std::atomic_int width, height;


public:


	OpenGL();
	~OpenGL();

	Event<OpenGL*, MouseWheelEventArg> WheelEvent;
	Event<OpenGL*, MouseEventArg> MouseMovieEvent;
	Event<OpenGL*, MouseEventArg> MouseLeaveEvent;
	Event<OpenGL*, MouseEventArg> MouseLupEvent;
	Event<OpenGL*, MouseEventArg> MouseLdownEvent;
	Event<OpenGL*, MouseEventArg> MouseRdownEvent;
	Event<OpenGL*, MouseEventArg> MouseRupEvent;
	Event<OpenGL*, MouseEventArg> MouseMdownEvent;
	Event<OpenGL*, MouseEventArg> MouseMupEvent;
	Event<OpenGL*, KeyEventArg> KeyUpEvent;
	Event<OpenGL*, KeyEventArg> KeyDownEvent;

	int getHeight()
	{
		return height;
	}

	int getWidth()
	{
		return width;
	}

	void setHWND(HWND window);

	void wheelEvent(float delta);
	void mouseMovie(short mX, short mY);
	void mouseLeave(short mX, short mY);

	void mouseLdown(short mX, short mY);
	void mouseLup(short mX, short mY);

	void mouseRdown(short mX, short mY);
	void mouseRup(short mX, short mY);
	
	void mouseMdown(short mX, short mY);
	void mouseMup(short mX, short mY);

	void keyDown(int key);
	void keyUp(int key);

	void DrawAxes();

	void render(double);

	void resize(int w, int h);
	void try_to_resize(int w, int h);

	void init(void);


	static bool isKeyPressed(int key)
	{
		short state = GetAsyncKeyState(key);

		return (bool)(state & 0x8000);
	}

};



