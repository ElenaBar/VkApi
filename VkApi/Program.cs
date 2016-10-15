using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Linq;
//using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
//using System.Threading.Tasks;

namespace VkApi{
    public class Program{
        static void Main(string[] args){
            //Console.WriteLine("https://oauth.vk.com/authorize?client_id=" + VkApi.client_id + "&display=mobile&redirect_uri=" + VkApi.redirect_uri + "&scope=" + VkApi.scope + "&response_type=token&v=" + VkApi.version);


            //OAuth авторизация
            //Process.Start("https://oauth.vk.com/authorize?client_id=" + VkApi.client_id + "&display=page&redirect_uri=" + VkApi.redirect_uri + "&scope=" + VkApi.scope + "&response_type=token&v=" + VkApi.version);

            //Console.WriteLine("Теперь вставляйте access_token: ");
            //VkApi.SetVkAccessToken(Console.ReadLine());
            //
            

            VkApi.SetVkAccessToken("87db11df3a0def5dc51c187bb4b05d493d57f932a34fedd625120a562673b79ddb50cece8fd0c6dcd09e6");

            Stopwatch timeGetMembersFriends = new Stopwatch();  //Старт секундомера
            timeGetMembersFriends.Start();                      //составления графа

            String groupName = "csu_iit";

            List<VkUser> groupMebersList = VkApi.GetGroupMembersGraph(groupName);
            //List<ContentPost> elenka_kolenka = VkApi.GetWall("elenka_kolenka");
            List<ContentPost> listnews = new List<ContentPost>();
            listnews = groupMebersList[528].GetNews(); //получение новостей
            // TODO sort ListNews

            /*---------------------------------------------------------------------*/
            timeGetMembersFriends.Stop();
            Console.WriteLine("RunTime " + FormatTime(timeGetMembersFriends));
            /*---------------------------------------------------------------------*/

            Console.ReadKey();
        }

        public static string UTF8ToWin1251(string source){

            Encoding utf8 = Encoding.GetEncoding("utf-8");
            Encoding win1251 = Encoding.GetEncoding("windows-1251");

            byte[] utf8Bytes = utf8.GetBytes(source);
            byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
            source = utf8.GetString(win1251Bytes);
            return source;
        }

        public static String FormatTime(Stopwatch time){
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = time.Elapsed;

            // Format and display the TimeSpan value.
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
        }
    }
}
