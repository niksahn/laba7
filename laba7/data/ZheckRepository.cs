using laba7.data.OOP1lb.Data;
using laba7.ui;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace laba7.data
{
    internal class ZheckListRepository : ZheckRepository
    {
      private ObservableCollection<Zheck> zhecks;

        public event EventHandler<List<Zheck>> updated;

        public ZheckListRepository() {
            zhecks = new ObservableCollection<Zheck>();
            zhecks.CollectionChanged += (i, a) => {   
                updated?.Invoke(this,zhecks.ToList());
            };
        }

        public  List<Zheck> getZhecks() {
            updated.Invoke(null, zhecks.ToList());
            return zhecks.ToList();
        }
        public  void addZheck(Zheck zheck) { zhecks.Add(zheck); }
        public  void changeZheck(Zheck zheck) {
            var i = zhecks.ToList().FindIndex((z) => { return z.Number1 == zheck.Number1; });
            zhecks[i] = zheck;
        }
        public  void deleteZheck(long zheckId)
        {
            var i = zhecks.ToList().FindIndex((z) => { return z.Number1 == zheckId; });
            zhecks.RemoveAt(i);
        }
        public Zheck byId(int id) { 
         return zhecks[id];
                }

    }

    interface ZheckRepository
    {
          void addZheck(Zheck zheck);
          void changeZheck(Zheck zheck);
          void deleteZheck(long zheckId);
            Zheck byId(int id);
          List<Zheck> getZhecks();
          event EventHandler<List<Zheck>> updated;
    }
}
