using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWatchlist.DomainModel;
using Neo4jClient.Cypher;

namespace MyWatchlist.DomainModel
{
    public class DataProvider
    {
        public static GraphClient client;

        public static bool Connect()
        {
            try
            {
                client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "neo4j123");
                client.Connect();
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        public static bool addUser(User u)
        {
            try
            {
                u.id = getId();
                client.Cypher
                .Create("(user:User {newUser})")
                .WithParam("newUser", u)
                .ExecuteWithoutResults();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static bool addActor(Actor a,List<Award> awards)
        {
            try
            {
                a.id = getId();
                client.Cypher
                .Create("(actor:Actor {newActor})")
                .WithParam("newActor", a)
                .ExecuteWithoutResults();
               // return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            foreach (Award award in awards)
            {
                if (!addAward(award))
                    return false;
                if (!ActorAward(a, award))
                    return false;
            }
            return true;
        }
        public static bool addAward(Award a)
        {         
            try
            {
                a.id = getId();
                client.Cypher
                .Create("(award:Award {newAward})")
                .WithParam("newAward", a)
                .ExecuteWithoutResults();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static bool ActorAward(Actor a, Award aw)
        {
            try
            {
                var query = client.Cypher
                .Match("(actor:Actor)", "(award:Award)")
                .Where((Award award) => award.id == aw.id)
                .AndWhere((Actor actor) => actor.id == a.id)
                .CreateUnique("(actor)-[hasAward:hasAward]->(award)");
                query.ExecuteWithoutResults();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static bool addCreator(Creator c)
        {
            try
            {
                c.id = getId();
                client.Cypher
                .Create("(creator:Creator {newCreator})")
                .WithParam("newCreator", c)
                .ExecuteWithoutResults();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static bool TVShowActor(TVShow tvshow, Actor act)
        {
            try
            {
                var query = client.Cypher
                .Match("(tvShow:TVShow)", "(actor:Actor)")
                .Where((TVShow tvShow) => tvShow.id == tvshow.id)
                .AndWhere((Actor actor) => actor.id == act.id)
                .CreateUnique("(tvShow)-[hasActor:hasActor]->(actor)");
                query.ExecuteWithoutResults();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool TVShowCreator(TVShow tvshow, Creator cr)
        {
            try
            {
                var query = client.Cypher
                .Match("(tvShow:TVShow)", "(creator:Creator)")
                .Where((TVShow tvShow) => tvShow.id == tvshow.id)
                .AndWhere((Creator creator) => creator.id == cr.id)
                .CreateUnique("(tvShow)-[hasCreator:hasCreator]->(creator)");
                query.ExecuteWithoutResults();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool TVShowGenre(TVShow tvshow, Genre g)
        {
            try
            {
                var query = client.Cypher
                .Match("(tvShow:TVShow)", "(genre:Genre)")
                .Where((TVShow tvShow) => tvShow.id == tvshow.id)
                .AndWhere((Genre genre) => genre.name == g.name)
                .CreateUnique("(tvShow)-[hasGenre:hasGenre]->(genre)");
                query.ExecuteWithoutResults();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool addTVShow(TVShow tvShow, List<Actor> actors, List<Creator> creators,List<Genre> genres)
        {
            try
            {
                tvShow.id = getId();
                client.Cypher
                .Create("(tvShow:TVShow {newTVShow})")
                .WithParam("newTVShow", tvShow)
                .ExecuteWithoutResults();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            foreach (Actor a in actors)
            {
                if (!TVShowActor(tvShow, a))
                    return false;
            }
            foreach (Creator c in creators)
            {
                if (!TVShowCreator(tvShow, c))
                    return false;
            }
            foreach (Genre g in genres)
            {
                if (!TVShowGenre(tvShow, g))
                    return false;
            }
            return true;
        }

        internal static List<TVShow> getAvailableTVShows(User u)
        {
            List<TVShow> vrati = client.Cypher
            .Match("(user:User)", "(tvshow:TVShow)")
            .Where((User user) => user.id == u.id)
            .AndWhere("NOT (((user)-[:watched]-(tvshow)))")
            .AndWhere("NOT (((user)-[:planToWatchh]-(tvshow)))")
            .Return(tvshow => tvshow.As<TVShow>())
            .Results.ToList();

            return vrati;
        }

        public static List<Award> getAwardsForActor(Actor a)
        {
            List<Award> vrati = client.Cypher
            .Match("(actor:Actor)", "(award:Award)")
            .Where((Actor actor) => actor.id == a.id)
            .AndWhere("(actor)-[:hasAward]-(award)")
            .Return(award => award.As<Award>())
            .Results.ToList();

            return vrati;
        }

        internal static bool testRelRate(User u, TVShow tv)
        {
            try
            {
                bool tmp = false;
                var lazy = client.Cypher
                      .Match("(user:User {id:" + u.id + "})")
                      .OptionalMatch("(user)-[r:Rate]->(tvshow:TVShow)")
                      .Where("tvshow.id = " + tv.id)
                      //.OnCreate().Set("tmpp=false")
                      .Return((user, tvshow) => new
                      {
                          User = user.As<User>(),
                          TVShow = tvshow.As<TVShow>(),
                          Rate = Return.As<bool>("NOT (r IS NULL)")

                      });

                if (lazy.Results == null)
                    return false;
                else
                {
                    foreach (var result in lazy.Results)
                    {
                        tmp = result.Rate;
                    }
                }

                if (tmp)
                    return false;
                else
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        internal static bool addRate(User u, TVShow tv)
        {
            try
            {
                //u.id = getId();
                var query = client.Cypher
                     .Match("(user:User)", "(tvshow:TVShow)")
                     .Where((User user) => user.id == u.id)
                     .AndWhere((TVShow tvshow) => tvshow.title == tv.title)
                     .Create("(user)-[r:Rate]->(tvshow)");
                query.ExecuteWithoutResults();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static List<TVShow> getPlanToWatch(User u)
        {
            List<TVShow> vrati = client.Cypher
           .Match("(user:User)", "(tvshow:TVShow)")
           .Where((User user) => user.id == u.id)
           .AndWhere("(user)-[:planToWatchh]-(tvshow)")
           .Return(tvshow => tvshow.As<TVShow>())
           .Results.ToList();

            return vrati;
        }

        public static bool findAdmin(Admin a)
        {
            List<Admin> rez = client.Cypher
            .Match("(admin:Admin)")
            .Where((Admin admin) => admin.Email == a.Email)
            .AndWhere((Admin admin) => admin.Password == a.Password)
            .Return(admin => admin.As<Admin>())
            .Results.ToList();
            if (rez.Count > 0)
                return true;
            else return false;
        }

        internal static List<TVShow> findTvShowReleased(string year, User u)
        {
            List<TVShow> rez = client.Cypher
            .Match("(tvshow:TVShow)", "(user:User)")
            .Where((TVShow tvshow) => tvshow.released == year)
            .AndWhere((User user) => user.id == u.id)
            .AndWhere("NOT (((user)-[:watched]-(tvshow)))")
            .AndWhere("NOT (((user)-[:planToWatchh]-(tvshow)))")
            .Return(tvshow => tvshow.As<TVShow>())
            .Results.ToList();
            return rez;
        }

        public static bool deleteTVshow(TVShow tv)
        {
            try
            {
                client.Cypher
                .Match("(tvShow:TVShow)", "(user:User")
                .Where((TVShow tvShow) => tvShow.id == tv.id)
                .DetachDelete("tvShow")
                .ExecuteWithoutResults();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool UpdateTVShow(TVShow tv)
        {
            try
            {
                client.Cypher
                .Match("(tvShow:TVShow)")
                .Where((TVShow tvShow) => tvShow.id == tv.id)
                .Set("tvShow={newTVShow}")
                .WithParam("newTVShow", tv)
                .ExecuteWithoutResults();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static List<Genre> getGenresFromShow(TVShow tv)
        {
            List<Genre> vrati = client.Cypher
             .Match("(genre:Genre)", "(tvshow:TVShow)")
             .Where((TVShow tvshow) => tvshow.id == tv.id)
             .AndWhere("(((tvshow)-[:hasGenre]-(genre)))")
             .Return(genre => genre.As<Genre>())
             .Results.ToList();

            return vrati;
        }

        public static List<Actor> getActorsFromShow(TVShow tv)
        {
            List<Actor> vrati = client.Cypher
             .Match("(actor:Actor)", "(tvshow:TVShow)")
             .Where((TVShow tvshow) => tvshow.id == tv.id)
             .AndWhere("(((tvshow)-[:hasActor]-(actor)))")
             .Return(actor => actor.As<Actor>())
             .Results.ToList();

            return vrati;
        }
        public static List<Creator> getCreatorsFromShow(TVShow tv)
        {
            List<Creator> vrati = client.Cypher
             .Match("(creator:Creator)", "(tvshow:TVShow)")
             .Where((TVShow tvshow) => tvshow.id == tv.id)
             .AndWhere("(((tvshow)-[:hasCreator]-(creator)))")
             .Return(creator => creator.As<Creator>())
             .Results.ToList();

            return vrati;
        }
        public static List<Actor> getAvailableActors(TVShow tv)
        {
            List<Actor> vrati = client.Cypher
             .Match("(actor:Actor)", "(tvshow:TVShow)")
             .Where((TVShow tvshow) => tvshow.id == tv.id)
             .AndWhere("NOT (((tvshow)-[:hasActor]-(actor)))")

             .Return(actor => actor.As<Actor>())
             .Results.ToList();

            return vrati;
        }
        public static bool addPlanToWatch(User u, TVShow tv)
        {
            try
            {
                //u.id = getId();
                var query = client.Cypher
                     .Match("(user:User)", "(tvshow:TVShow)")
                     .Where((User user) => user.id == u.id)
                     .AndWhere((TVShow tvshow) => tvshow.title == tv.title)
                     .Create("(user)-[planToWatchh:planToWatchh ]->(tvshow)");
                query.ExecuteWithoutResults();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static bool deletePlanToWatch(User u, TVShow tv)
        {
            try
            {

                new CypherFluentQuery(client)
                .Match("(user)-[p:planToWatchh]->(tvshow)")
                .Where((User user) => user.id == u.id)
                .AndWhere((TVShow tvshow) => tvshow.title == tv.title)
                .Delete("p").ExecuteWithoutResults();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static List<TVShow> getShowsWithActor(string name, User u)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("actorName", name);
            queryDict.Add("userId", u.id);

            var query = new Neo4jClient.Cypher.CypherQuery("match (tvshow:TVShow)-[h:hasActor]->(actor:Actor),(user:User{id:{userId}}) WHERE NOT (user)-[:watched]-(tvshow) AND NOT(user)-[:planToWatchh]-(tvshow) AND actor.firstName CONTAINS {actorName} OR actor.lastName CONTAINS {actorName} return tvshow",
                                                            queryDict, CypherResultMode.Set);

            List<TVShow> shows = ((IRawGraphClient)client).ExecuteGetCypherResults<TVShow>(query).ToList();
            return shows;
        }

        public static List<TVShow> getShowsWithGenre(Genre g,User u)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("genreName", g.name);
            queryDict.Add("userId", u.id);

            var query = new Neo4jClient.Cypher.CypherQuery("match (tvshow:TVShow)-[h:hasGenre]->(genre:Genre),(user:User{id:{userId}}) WHERE NOT (user)-[:watched]-(tvshow) AND NOT(user)-[:planToWatchh]-(tvshow) AND genre.name = {genreName} return tvshow",
                                                            queryDict, CypherResultMode.Set);

            List<TVShow> shows = ((IRawGraphClient)client).ExecuteGetCypherResults<TVShow>(query).ToList();
            return shows;
        }

        public static bool addWatched(User u, TVShow tv)
        {
            try
            {
                var query = client.Cypher
                     .Match("(user:User)", "(tvshow:TVShow)")
                     .Where((User user) => user.id == u.id)
                     .AndWhere((TVShow tvshow) => tvshow.title == tv.title)
                     .Create("(user)-[watched:watched ]->(tvshow)");
                query.ExecuteWithoutResults();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static List<DomainModel.TVShow> planToWatchFunc(User u)
        {
            try
            {
                List<DomainModel.TVShow> serije = client.Cypher
                    .Match("(user)-[planToWatchh:planToWatchh ]->(tvshow)")
                    .Where((User user) => user.id == u.id)
                    .Return(tvshow => tvshow.As<TVShow>()).Results.ToList();
                return serije;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;

            }
        }
        public static List<DomainModel.TVShow> WatchedFunc(User u)
        {
            try
            {
                List<DomainModel.TVShow> serije = client.Cypher
                    .Match("(user)-[watched:watched ]->(tvshow)")
                    .Where((User user) => user.id == u.id)
                    .Return(tvshow => tvshow.As<TVShow>()).Results.ToList();
                return serije;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;

            }
        }
        public static User findUser(string username, string password)
        {
            List<User> rez = client.Cypher
            .Match("(user:User)")
            .Where((User user) => user.email == username)
            .AndWhere((User user) => user.password == password)
            .Return(user => user.As<User>())
            .Results.ToList();
            if (rez.Count > 0)
                return rez[0];
            else return null;
        }

        public static List<TVShow> findTvShow(string title,User u)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("tvTitle", title);
            queryDict.Add("userId", u.id);

            var query = new Neo4jClient.Cypher.CypherQuery("match (tvshow:TVShow),(user:User{id:{userId}}) WHERE NOT (user)-[:watched]-(tvshow) AND NOT(user)-[:planToWatchh]-(tvshow) AND tvshow.title CONTAINS {tvTitle} return tvshow",
                                                            queryDict, CypherResultMode.Set);

            List<TVShow> shows = ((IRawGraphClient)client).ExecuteGetCypherResults<TVShow>(query).ToList();
            return shows;
        }

        public static List<Creator> getAvailableCreators(TVShow tv)
        {
            List<Creator> vrati = client.Cypher
             .Match("(creator:Creator)", "(tvshow:TVShow)")
             .Where((TVShow tvshow) => tvshow.id == tv.id)
             .AndWhere("NOT ((tvshow-[:hasCreator]-creator))")
             .Return(creator => creator.As<Creator>())
             .Results.ToList();

            return vrati;
        }

        public static List<Actor> getActors()
        {
            List<Actor> vrati = client.Cypher
             .Match("(actor:Actor)")
             .Return(actor => actor.As<Actor>())
             .Results.ToList();

            return vrati;
        }

        public static List<Creator> getCreators()
        {
            List<Creator> vrati = client.Cypher
             .Match("(creator:Creator)")
             .Return(creator => creator.As<Creator>())
             .Results.ToList();

            return vrati;
        }

        public static List<TVShow> getTVShows()
        {
            List<TVShow> vrati = client.Cypher
             .Match("(tvShow:TVShow)")
             .Return(tvShow => tvShow.As<TVShow>())
             .Results.ToList();

            return vrati;
        }

        public static List<Genre> getGenres()
        {
            List<Genre> vrati = client.Cypher
             .Match("(genre:Genre)")
             .Return(genre => genre.As<Genre>())
             .Results.ToList();

            return vrati;
        }

        public static List<Actor> getActor(string name)
        {
            string actorName = name;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("actorName", actorName);

            var query = new Neo4jClient.Cypher.CypherQuery("match (n:Actor) where n.firstName CONTAINS {actorName} or n.lastName CONTAINS {actorName} return n",
                                                            queryDict, CypherResultMode.Set);

            List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();
            return actors;
        }

        public static List<Creator> getCreator(string name)
        {
            string creatorName = name;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("creatorName", creatorName);

            var query = new Neo4jClient.Cypher.CypherQuery("match (n:Creator) where n.firstName CONTAINS {creatorName} or n.lastName CONTAINS {creatorName} return n",
                                                            queryDict, CypherResultMode.Set);

            List<Creator> creators = ((IRawGraphClient)client).ExecuteGetCypherResults<Creator>(query).ToList();
            return creators;
        }

        public static long getId()
        {

            long povratak;
            IdNode vrati = client.Cypher
            .Match("(i:IdNode)")
            .Return(i => i.As<IdNode>())
            .Results.ToList()[0];
            povratak = vrati.id;
            IdNode novi = new IdNode();
            novi.id = povratak + 1;

            try
            {
                client.Cypher
                .Match("(i:IdNode)")
                .Where((IdNode i) => i.id == povratak)
                .Set("i = {novicvor}")
                .WithParam("novicvor", novi)
                .ExecuteWithoutResults();
                return povratak;
            }

            catch (Exception e)
            {
                return -1;
            }
        }

        public static string getMostFrequentSService(User u)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("userId", u.id);

            string s;
            var query = new Neo4jClient.Cypher.CypherQuery("match (:User{id:{userId}})-[w:watched]-(tvshow:TVShow) WITH tvshow.streamingService as streamingService, count(*) as times WITH collect({ streamingService:streamingService, times: times}) as rows, max(times) as max UNWIND[row in rows WHERE row.times = max] as row RETURN row.streamingService as name", queryDict, CypherResultMode.Set);
            var result = ((IRawGraphClient)client).ExecuteGetCypherResults<string>(query);
            s=result.FirstOrDefault();
            return s;
        }

        public static List<Genre> getMostFrequentGenre(User u)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("userId", u.id);

            List<Genre> genres=new List<Genre>();
            var query = new Neo4jClient.Cypher.CypherQuery("match (u:User{id:{userId}})-[w:watched]->(tvshow:TVShow),(tvshow)-[:hasGenre]-(genre:Genre) WITH genre, count(*) as times WITH collect({ genre:genre, times: times}) as rows UNWIND[row in rows] as row RETURN row.genre as name order by row.times desc", queryDict, CypherResultMode.Set);
            var result = ((IRawGraphClient)client).ExecuteGetCypherResults<Genre>(query);
            foreach (Genre g in result)
            {
                genres.Add(g);
            }
            return genres;
        }

        public static List<TVShow> findRecommended(string streamingService, List<Genre> g, User u)
        {
            List<TVShow> shows = new List<TVShow>();
            Genre g1 = g[0];
            Genre g2 = g[1];
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("userId", u.id);
            queryDict.Add("genreName1", g1.name);
            queryDict.Add("genreName2", g2.name);
            queryDict.Add("ss", streamingService);
            
            var query = new Neo4jClient.Cypher.CypherQuery("match(u: User{ id:{userId}}),(tvshow: TVShow),(genre: Genre{ name: {genreName1}}), (genre1: Genre{ name: {genreName2}}) WHERE NOT (u)-[:watched] - (tvshow) AND NOT (u)-[:planToWatchh]-(tvshow) AND(tvshow.streamingService={ss} OR (tvshow)-[:hasGenre]-(genre) OR (tvshow)-[:hasGenre]-(genre1)) return tvshow", queryDict, CypherResultMode.Set);
            var result = ((IRawGraphClient)client).ExecuteGetCypherResults<TVShow>(query);
            foreach (TVShow t in result)
            {
                shows.Add(t);
            }
            return shows;
        }

        public static List<TVShow> findMostPopular(User u)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("userId", u.id);
            List<TVShow> shows = new List<TVShow>();
            var query = new Neo4jClient.Cypher.CypherQuery("match(u: User{ id:{userId}}),(tvshow: TVShow),(:User)-[w:watched]-(:TVShow) WHERE NOT (u)-[:watched] - (tvshow) AND NOT (u)-[:planToWatchh]-(tvshow) WITH count(w) as count, tvshow as tv return tv order by count desc", queryDict, CypherResultMode.Set);
            var result = ((IRawGraphClient)client).ExecuteGetCypherResults<TVShow>(query);
            foreach (TVShow t in result)
            {
                shows.Add(t);
            }
            return shows;
        }
        public static List<TVShow> findBestRated(User u)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("userId", u.id);
            List<TVShow> shows = new List<TVShow>();
            var query = new Neo4jClient.Cypher.CypherQuery("match(u: User{ id:{userId}}),(tvshow: TVShow) WHERE NOT (u)-[:watched] - (tvshow) AND NOT (u)-[:planToWatchh]-(tvshow) WITH tvshow.stars as rate, tvshow as tv return tv order by rate desc", queryDict, CypherResultMode.Set);
            var result = ((IRawGraphClient)client).ExecuteGetCypherResults<TVShow>(query);
            foreach (TVShow t in result)
            {
                shows.Add(t);
            }
            return shows;
        }
    }
}
