using myWCF_RESTfulService.Data.Models; //Importing Data Contracts for the Service
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace myWCF_RESTfulService
{
    
    [ServiceContract]
    public interface IGameService
    {
        [WebInvoke(Method = "*",UriTemplate = "GetGame/{id}", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        Game GetGame(string id);

        [WebGet(UriTemplate = "GameList", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Game> GameList();

        [OperationContract]
        void AddGame(Game newGame);

        [OperationContract]
        void  UpdateGame(Game newGame);

        [OperationContract]
        void  DeleteGame(int id);


    }




}
