// using Newtonsoft.Json.Linq;

// namespace patting_server
// {
//     public class Info
//     {
//         private JObject usersInfo = new JObject();
//         private JObject aiInfo = new JObject();

//         public Map UsersInfo
//         {
//                 get
//                 {
//                         return usersInfo;
//                 }

            
//                 set
//                 {
//                 lock(usersInfo){
//                         usersInfo = value;
//                 }
//                 }
//         }

//         public Map AiInfo
//         {
//                 get
//                 {
//                         return aiInfo;
//                 }

            
//                 set
//                 {
//                 lock(aiInfo){
//                         aiInfo = value;
//                 }
//                 }
//         }
//     }
// }