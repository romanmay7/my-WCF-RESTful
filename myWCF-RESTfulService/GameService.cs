using myWCF_RESTfulService.Data;
using myWCF_RESTfulService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace myWCF_RESTfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class GameService : IGameService
    {
        public void AddGame(Game newGame)
        {
            GameServiceRepository.Instance.Add(newGame);
        }

        public void DeleteGame(int id)
        {
            GameServiceRepository.Instance.Delete(System.Convert.ToInt32(id));
        }

        public List<Game> GameList()
        {
            return GameServiceRepository.Instance.GetList();
        }

        public Game GetGame(string id)
        {
            IEnumerable<Game> empList = GameServiceRepository.Instance.GetList().Where(x => x.Id.ToString() == id);

            if (empList != null)
                return empList.First<Game>();
            else
                return null;
        }
    
        public void UpdateGame(Game newGame)
         {
            GameServiceRepository.Instance.Update(newGame);
         }
    }
}
