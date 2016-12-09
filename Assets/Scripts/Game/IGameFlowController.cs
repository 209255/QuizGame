using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public interface IGameFlowController
    {
        void OnCategorySelected(string category);
        void OnFinishQuestions();
    }

