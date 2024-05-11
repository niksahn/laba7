using laba7.data;
using laba7.data.OOP1lb.Data;
using laba7.others;
using System;
using System.Collections.Generic;

namespace laba7.ui
{
    internal class Controller
    {
        ZheckRepository _repo;
        List<ZheckVeiw> _view;

        public Controller(List<ZheckVeiw> view, ZheckRepository repo)
        {
            _view = view;
            _repo = repo;
            view.ForEach((i)=>{ i.SetController(this); });
        }

        public void addZheck(Zheck z)
        {
            try
            {
                _repo.addZheck(z);   
            }
            catch (MyException e)
            {
                _view.ForEach((i) =>
                {
                    i.error = e.Message;
                });
            }
            catch (Exception){
                _view.ForEach((i) => { i.error = "Неверное значение одного или нескольких полей ";});
            }
        }
        public void getZhecks()
        {
            _repo.getZhecks();
        }

        public void changeZheck(Zheck z)
        {
            try
            {
                _repo.changeZheck(z);
            }
            catch(MyException e)
            {
                _view.ForEach((i) =>
                {
                    i.error = e.Message;
                });
            }
            catch (Exception)
            {
                _view.ForEach((i) =>
                {
                    i.error = "Неверное значение одного или нескольких полей ";
                });
            }
        }

        public Zheck getById(int id)
        {
            try
            {
               return _repo.byId(id);
            }
            catch (Exception)
            {
                _view.ForEach((i) => { i.error = "Не выбран элемент "; });
                return null;
            }
        }

        public void removeZheck(int id)
        {
            try
            {
                _repo.deleteZheck(id);
            }
            catch (Exception)
            {
                _view.ForEach((i) => { i.error = "Не выбран элемент "; });
            }
        }
        public void RunView()
        {
            _view.ForEach((i) => { i.Run(_repo); });
        }
    }
}
