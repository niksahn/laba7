using laba7.data;
using System;

namespace laba7.ui
{
    interface ZheckVeiw
    {
        void SetController(Controller controller);
        void Run(ZheckRepository repo);
        String error { set; }
    }
}
