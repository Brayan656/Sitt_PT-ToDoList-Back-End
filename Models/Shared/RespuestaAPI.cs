﻿using System.Net;

namespace ToDoList.Models.Shared
{
    public class RespuestaAPI
    {
        public RespuestaAPI()
        {
            ErrorMessage = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessage { get; set; }
        public object Result { get; set; }
    }
}