#region using directives

using System;

using Akka.Actor;
using Akka.Configuration;

#endregion

namespace Akka.Net_Remote_Server
{
    class Program
    {
        #region Private Methods

        private static void Main()
        {
            Config config = ConfigurationFactory.ParseString(@"
            akka {  
                actor {
                    provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                    serializers {
                        wire = ""Akka.Serialization.WireSerializer, Akka.Serialization.Wire""
                    }
                    serialization-bindings {
                        ""System.Object"" = wire
                    }
                }
                remote {
                    helios.tcp {
                        port = 8989
                        hostname = FUEPC-0091.naip.de
                        enable-ssl = true
                    }
                    helios.ssl {
                        enable-ssl = true
                        security {
                            protocol = ""TLSv1.2""
                        }                        
                    }
                }
            }");

            ActorSystem actorSystem = ActorSystem.Create("MyServer", config);

            actorSystem.ActorOf<MyServerActor>("MyServerActor");

            Console.ReadLine();
        }

        #endregion
    }
}