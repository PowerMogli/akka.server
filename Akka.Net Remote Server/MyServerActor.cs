#region using directives

using Akka.Actor;

using Naip.CommunicationMessages.Messages;

#endregion

namespace Akka.Net_Remote_Server
{
    public class MyServerActor : ReceiveActor
    {
        #region Construction

        public MyServerActor()
        {
            Receive<ReliableDeliveryEnvelope<ChangePrescriptionStatusToIssued>>(msg =>
            {
                Sender.Tell(new ReliableDeliveryAck(msg.MessageId));
            });

            Receive<ReliableDeliveryEnvelope<ChangePrescriptionStatusToNotIssued>>(msg =>
            {
                Sender.Tell(new ReliableDeliveryAck(msg.MessageId));
            });
        }

        #endregion
    }
}