﻿namespace GraphQLWebAPI.Infra
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public bool Publicado { get; set; }
        public virtual Usuario Autor { get; set; }
    }
}