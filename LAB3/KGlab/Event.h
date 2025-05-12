//небольшая самописная библиотека для работы с событиями
#pragma once

#include <list>
#include <functional>
#include <mutex>


//Объект этого класса хранит в себе массив указателей на функции
//которые последовательно исполняются
//при вызове exec()
//SENDTYPE - тип отправителя события (сигнала)
//ARGTYPE  - тип параметра сигнала
template <class SENDTYPE, class ARGTYPE>
class Event
{
	//определяем тип - указатель на функцию
	//епрвым аргументом функция должна принимать указатель на отправителья события
	//вторым  аргумент события.
	typedef  std::function<void(SENDTYPE, ARGTYPE)> event_func_type;
	//итератор на функцию в списке
	typedef  typename  std::list<event_func_type>::const_iterator  event_func_type_const_iterator;

	//список функций
	std::list<event_func_type> events;	  

	//блокировщик для многопоточности
	std::mutex event_lock;
	   
public:

	//добавление одиночной функции
   event_func_type_const_iterator reaction(event_func_type event_func)
   {	   
	   event_lock.lock();
	   events.push_back(event_func);
	   event_lock.unlock();
	   return --events.end();
   } 

   //добавление функции-члена какого нибудь класса
   template<class C>		   
   event_func_type_const_iterator reaction(C* cls, void(C::*f)(SENDTYPE, ARGTYPE))
   {
	   using namespace std::placeholders;
	   event_func_type f1;
	   f1 = std::bind(f, cls, _1, _2);
	   event_lock.lock();
	   events.push_back(f1);	
	   event_lock.unlock();
	   return --events.end();
   }


   //удаляет функцию по ее итератору
   void remove_reaction(event_func_type_const_iterator &it)
   {
	   event_lock.lock();
	   events.erase(it);
	   event_lock.unlock();
   }

   //удаляет функцию по ее указателю
   template<class C>
   void remove_reaction(C* cls, void(C::*f)(SENDTYPE, ARGTYPE))
   {
	   using namespace std::placeholders;
	   event_func_type f1;
	   f1 = std::bind(f, cls, _1, _2);
	   event_lock.lock();
	   events.remove(f1);
	   event_lock.unlock();
   }

   //удаляет функцию по ее итератору
   void remove_reaction(event_func_type f)
   {
	   event_lock.lock();
	   events.remove(f);
	   event_lock.unlock();
   }

   //удалить все!
   void remove_all_reations()
   {
	   event_lock.lock();
	   events.clear();
	   event_lock.unlock();
   }

   //выпонить все функции
   //первым аргументом отправить во все функции
   //указатель на отправителя сигнала
   //вторым - параметры сигнала.
   void exec(SENDTYPE sender,ARGTYPE args)
   {
	   event_lock.lock();
	   for (auto x : events)
		   x(sender,args);
	   event_lock.unlock();
   }  

};
