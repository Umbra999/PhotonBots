using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Photon;
using Photon.Realtime;
using ExitGames.Client.Photon;

namespace TheBotUI.Core
{
    static class CustomTypes
    {
        private static LoadBalancingClient Client;

        internal static void Register(LoadBalancingClient client)
        {
            Client = client;
        }

        public static readonly byte[] memVector3 = new byte[3 * 4];

        private static short SerializeVector3(StreamBuffer outStream, object customobject)
        {
            Vector3 vo = (Vector3)customobject;

            int index = 0;
            lock (memVector3)
            {
                byte[] bytes = memVector3;
                Protocol.Serialize(vo.x, bytes, ref index);
                Protocol.Serialize(vo.y, bytes, ref index);
                Protocol.Serialize(vo.z, bytes, ref index);
                outStream.Write(bytes, 0, 3 * 4);
            }

            return 3 * 4;
        }

        private static object DeserializeVector3(StreamBuffer inStream, short length)
        {
            Vector3 vo = new Vector3();
            lock (memVector3)
            {
                inStream.Read(memVector3, 0, 3 * 4);
                int index = 0;
                Protocol.Deserialize(out vo.x, memVector3, ref index);
                Protocol.Deserialize(out vo.y, memVector3, ref index);
                Protocol.Deserialize(out vo.z, memVector3, ref index);
            }

            return vo;
        }


        public static readonly byte[] memVector2 = new byte[2 * 4];

        private static short SerializeVector2(StreamBuffer outStream, object customobject)
        {
            Vector2 vo = (Vector2)customobject;
            lock (memVector2)
            {
                byte[] bytes = memVector2;
                int index = 0;
                Protocol.Serialize(vo.x, bytes, ref index);
                Protocol.Serialize(vo.y, bytes, ref index);
                outStream.Write(bytes, 0, 2 * 4);
            }

            return 2 * 4;
        }

        private static object DeserializeVector2(StreamBuffer inStream, short length)
        {
            Vector2 vo = new Vector2();
            lock (memVector2)
            {
                inStream.Read(memVector2, 0, 2 * 4);
                int index = 0;
                Protocol.Deserialize(out vo.x, memVector2, ref index);
                Protocol.Deserialize(out vo.y, memVector2, ref index);
            }

            return vo;
        }


        public static readonly byte[] memQuarternion = new byte[4 * 4];

        private static short SerializeQuaternion(StreamBuffer outStream, object customobject)
        {
            Quaternion o = (Quaternion)customobject;

            lock (memQuarternion)
            {
                byte[] bytes = memQuarternion;
                int index = 0;
                Protocol.Serialize(o.w, bytes, ref index);
                Protocol.Serialize(o.x, bytes, ref index);
                Protocol.Serialize(o.y, bytes, ref index);
                Protocol.Serialize(o.z, bytes, ref index);
                outStream.Write(bytes, 0, 4 * 4);
            }

            return 4 * 4;
        }

        private static object DeserializeQuaternion(StreamBuffer inStream, short length)
        {
            Quaternion o = new Quaternion();

            lock (memQuarternion)
            {
                inStream.Read(memQuarternion, 0, 4 * 4);
                int index = 0;
                Protocol.Deserialize(out o.w, memQuarternion, ref index);
                Protocol.Deserialize(out o.x, memQuarternion, ref index);
                Protocol.Deserialize(out o.y, memQuarternion, ref index);
                Protocol.Deserialize(out o.z, memQuarternion, ref index);
            }

            return o;
        }

        public static readonly byte[] memVector4 = new byte[4 * 4];

        private static short SerializeVector4(StreamBuffer outStream, object customobject)
        {
            Vector4 o = (Vector4)customobject;

            lock (memQuarternion)
            {
                byte[] bytes = memQuarternion;
                int index = 0;
                Protocol.Serialize(o.w, bytes, ref index);
                Protocol.Serialize(o.x, bytes, ref index);
                Protocol.Serialize(o.y, bytes, ref index);
                Protocol.Serialize(o.z, bytes, ref index);
                outStream.Write(bytes, 0, 4 * 4);
            }

            return 4 * 4;
        }

        private static object DeserializeVector4(StreamBuffer inStream, short length)
        {
            Vector4 o = new Vector4();

            lock (memQuarternion)
            {
                inStream.Read(memQuarternion, 0, 4 * 4);
                int index = 0;
                Protocol.Deserialize(out o.w, memQuarternion, ref index);
                Protocol.Deserialize(out o.x, memQuarternion, ref index);
                Protocol.Deserialize(out o.y, memQuarternion, ref index);
                Protocol.Deserialize(out o.z, memQuarternion, ref index);
            }

            return o;
        }

        public static readonly byte[] memPlayer = new byte[4];

        private static short SerializePhotonPlayer(StreamBuffer outStream, object customobject)
        {
            int ID = ((Player)customobject).ActorNumber;

            lock (memPlayer)
            {
                byte[] bytes = memPlayer;
                int off = 0;
                Protocol.Serialize(ID, bytes, ref off);
                outStream.Write(bytes, 0, 4);
                return 4;
            }
        }

        private static object DeserializePhotonPlayer(StreamBuffer inStream, short length)
        {
            int ID;
            lock (memPlayer)
            {
                inStream.Read(memPlayer, 0, length);
                int off = 0;
                Protocol.Deserialize(out ID, memPlayer, ref off);
            }

            if (Client.CurrentRoom != null)
            {
                Player player = Client.CurrentRoom.GetPlayer(ID);
                return player;
            }
            return null;
        }
    }

    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public struct Quaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }

    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }

    public class RPC
    {
        public string rpcName;
        public string parameterString;
        public VrcEventType eventType;
        public VrcBroadcastType broadcastType;
        public byte[] parameterBytes;

        public static byte[] Serialize(object customType)
        {
            return new byte[32768];
        }

        public static object Deserialize(byte[] data)
        {
            RPC rpc = new RPC();
            int num = 0;
            float num2;
            Protocol.Deserialize(out num2, data, ref num);
            int num3;
            Protocol.Deserialize(out num3, data, ref num);
            short num4;
            Protocol.Deserialize(out num4, data, ref num);
            rpc.rpcName = Encoding.UTF8.GetString(data, num, num4);
            num += num4;
            int num5;
            Protocol.Deserialize(out num5, data, ref num);
            rpc.eventType = (VrcEventType)Enum.ToObject(typeof(VrcEventType), num5);
            short num6;
            Protocol.Deserialize(out num6, data, ref num);
            int num7;
            Protocol.Deserialize(out num7, data, ref num);
            float num8;
            Protocol.Deserialize(out num8, data, ref num);
            int num9;
            Protocol.Deserialize(out num9, data, ref num);
            Protocol.Deserialize(out num4, data, ref num);
            rpc.parameterString = Encoding.UTF8.GetString(data, num, num4);
            num += num4;
            try
            {
                float num10;
                Protocol.Deserialize(out num10, data, ref num);
                short num11;
                Protocol.Deserialize(out num11, data, ref num);
                rpc.broadcastType = (VrcBroadcastType)Enum.ToObject(typeof(VrcBroadcastType), num11);
                short num12;
                Protocol.Deserialize(out num12, data, ref num);
                rpc.parameterBytes = new byte[num12];
                if (num12 > 0)
                    Array.Copy(data, num, rpc.parameterBytes, 0, num12);
                num += num12;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                rpc.parameterBytes = new byte[0];
            }
            Console.WriteLine($"RPC Received | Target {rpc.rpcName} : ParamString {(string.IsNullOrEmpty(rpc.parameterString) ? "-empty-" : rpc.parameterString)} : EvType {rpc.eventType.ToString()} : BroadcType {rpc.broadcastType.ToString()} : SizeOfParamsBytes {rpc.parameterBytes.Length}");
            return rpc;
        }
    }

    public enum VrcEventType
    {
        // Token: 0x0400006A RID: 106
        MeshVisibility,
        // Token: 0x0400006B RID: 107
        AnimationFloat,
        // Token: 0x0400006C RID: 108
        AnimationBool,
        // Token: 0x0400006D RID: 109
        AnimationTrigger,
        // Token: 0x0400006E RID: 110
        AudioTrigger,
        // Token: 0x0400006F RID: 111
        PlayAnimation,
        // Token: 0x04000070 RID: 112
        SendMessage,
        // Token: 0x04000071 RID: 113
        SetParticlePlaying,
        // Token: 0x04000072 RID: 114
        TeleportPlayer,
        // Token: 0x04000073 RID: 115
        RunConsoleCommand,
        // Token: 0x04000074 RID: 116
        SetGameObjectActive,
        // Token: 0x04000075 RID: 117
        SetWebPanelURI,
        // Token: 0x04000076 RID: 118
        SetWebPanelVolume,
        // Token: 0x04000077 RID: 119
        SpawnObject,
        // Token: 0x04000078 RID: 120
        SendRPC,
        // Token: 0x04000079 RID: 121
        ActivateCustomTrigger,
        // Token: 0x0400007A RID: 122
        DestroyObject,
        // Token: 0x0400007B RID: 123
        SetLayer,
        // Token: 0x0400007C RID: 124
        SetMaterial,
        // Token: 0x0400007D RID: 125
        AddHealth,
        // Token: 0x0400007E RID: 126
        AddDamage,
        // Token: 0x0400007F RID: 127
        SetComponentActive,
        // Token: 0x04000080 RID: 128
        AnimationInt,
        // Token: 0x04000081 RID: 129
        AnimationIntAdd = 24,
        // Token: 0x04000082 RID: 130
        AnimationIntSubtract,
        // Token: 0x04000083 RID: 131
        AnimationIntMultiply,
        // Token: 0x04000084 RID: 132
        AnimationIntDivide,
        // Token: 0x04000085 RID: 133
        AddVelocity,
        // Token: 0x04000086 RID: 134
        SetVelocity,
        // Token: 0x04000087 RID: 135
        AddAngularVelocity,
        // Token: 0x04000088 RID: 136
        SetAngularVelocity,
        // Token: 0x04000089 RID: 137
        AddForce,
        // Token: 0x0400008A RID: 138
        SetUIText
    }

    public enum VrcBroadcastType
    {
        // Token: 0x0400008C RID: 140
        Always,
        // Token: 0x0400008D RID: 141
        Master,
        // Token: 0x0400008E RID: 142
        Local,
        // Token: 0x0400008F RID: 143
        Owner,
        // Token: 0x04000090 RID: 144
        AlwaysUnbuffered,
        // Token: 0x04000091 RID: 145
        MasterUnbuffered,
        // Token: 0x04000092 RID: 146
        OwnerUnbuffered,
        // Token: 0x04000093 RID: 147
        AlwaysBufferOne,
        // Token: 0x04000094 RID: 148
        MasterBufferOne,
        // Token: 0x04000095 RID: 149
        OwnerBufferOne
    }
}
