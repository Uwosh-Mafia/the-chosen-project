using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyFeudGame.Helpers
{
    class GameUI
    {
        GameLogicController controller;
        public GameUI(GameLogicController controller)
        {
            this.controller = controller;
        }

        public void clearAnswers() { }
        public void wrongAnswer()
        {
            controller.WrongAnswer();
        }

        public void correctAnswer(int id)
        {
            controller.CorrectAnswer(id);
        }

        public void fillAnswers(List<Answer> answers) {  }
        public void toggleAnswer() { }
    }
}



