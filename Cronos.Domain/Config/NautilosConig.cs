using Cronos.Domain.Entidades.Nautilos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Config
{
    public class NautilosConig
    {
        public string Id { get; set; }
        public string Securyte { get; set; }
        public string root { get; set; }
        public string rootApi { get; set; }
        public Rout rout { get; set; }
        public NautilosRequired required { get; set; }
    }
}
/*
  "id": "#load-html",
    "index": "Home",
    "securyte": true,
    "root": "http://127.0.0.1:80/Cronos/",
    "rootApi": "http://localhost:5000/api/",

    "rout": {
      "Home": [ "www/pags/home.html" ],
      "Login": [ "www/pags/login.html", "anonymous" ],
      "Livro": [ "www/pags/livro.html" ]
    },

    "required": {
      "scripts": [
        "www/Lib/less.js/dist/less.js",
        "www/Lib/anime-master/lib/anime.min.js",
        "www/js/Oper/main.js",
        "www/js/Enuns/Enum.js",
        "www/Lib/bootstrap/js/bootstrap.js",
        "www/Lib/datatables/js/jquery.dataTables.min.js",
        "www/Lib/datatables-responsive/dataTables.responsive.js",
        "www/Lib/datatables/js/dataTables.bootstrap4.min.js",
        "www/js/datatbles.js",
        "www/Lib/CryptoJS v3.1.2/components/cipher-core.js"
      ],

      "links": [
        "www/less/nautilos.less",
        "www/Lib/bootstrap/css/bootstrap.css",
        "www/less/layout.less",
        "www/css/site.less",
        "www/Lib/ChatBot/less/ChatStyle.less",
        "www/Lib/datatables/css/dataTables.bootstrap4.css",
        "www/Lib/datatables-plugins/dataTables.bootstrap.css",
        "www/Lib/datatables-responsive/dataTables.responsive.css"
      ],

      "partialViews": [
        {
          "view": "www/pags/Views.html",
          "ids": [ "Login", "NewUser", "NewLivro", "SubBodyLivros" ]
        }
      ]
    }
 */
