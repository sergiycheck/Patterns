using System;
using System.Collections.Generic;
using Patterns.models;


namespace Patterns.ChainOfResponsibility
{
    public class Client
    {


       public static void ClientLoader(AbstractLoader loader)
       {
           string path1 = @"https://getbootstrap.com/docs/4.4/examples/album/";
           string path0 = @"https://codebeautify.org/all-number-converter";
           string pathfile = @"E:/filesFromCDisk/templates/startbootstrap-grayscale-gh-pages/index.html"; 

           foreach (var path in new List<string>{ pathfile,path1, path0})
           {
               Console.WriteLine($"Client request to load {path}");
               var res = loader.Handle(path) as MyHtmlModel;
               if(res!=null)
                   Console.WriteLine($"Name: {res.Name} \n HTML: \n {res.HTML}");
               else
                Console.WriteLine($"{res.Name} was not found");               
           }
       }

    }
}
