using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Net.Sockets;

namespace Toolkit
{
	/// <summary>
	/// B2 input.
	/// </summary>
	public class B2Input
	{
		protected Stream input;
		
		public B2Input (byte[] buff)
		{
			input = new MemoryStream (buff);
		}
		
		public B2Input (Stream input2)
		{
			this.input = input2;
		}
		
		public virtual int read ()
		{
			int ch = input.ReadByte ();
			if (ch < 0)
				throw new EndOfStreamException();
			//return (byte)(ch);
			return (sbyte)ch;
		}

		public virtual int peek ()
		{
			int v = read ();
			input.Position --;
			return v;
		}
		
		public virtual int read (byte[] buf)
		{
			return input.Read (buf, 0, buf.Length);
		}

		public int readInt ()
		{
			return B2Serial.readInt (this);
		}
	}

	public class B2InputEncrypt : B2Input
	{
		
		public byte encrypt;
		
		public B2InputEncrypt (byte[] buf): base(buf)
		{
			this.encrypt = (byte)base.read ();
		}
		
		public B2InputEncrypt (byte[] buf, byte encrypt2):base(buf)
		{
			this.encrypt = encrypt2;
		}
		
		public B2InputEncrypt (Stream input2): base(input2)
		{
			this.encrypt = (byte)base.read ();
		}
		
		public B2InputEncrypt (Stream input2, byte encrypt): base(input2)
		{
			this.encrypt = encrypt;
		}
		
		public override int read ()
		{
			int b = (byte)base.read ();
			b = b ^ encrypt;
			return (sbyte)b;
		}
	}


	/// <summary>
	/// B2 output.
	/// </summary>
	public class B2Output
	{
		protected Stream output;

		public B2Output (Stream output2)
		{
			this.output = output2;
		}

		public virtual void write (int b)
		{
			output.WriteByte ((byte)b);
		}

		public virtual void writeInt (int v)
		{
			B2Serial.writeInt (this, v);
		}

		public virtual void write (byte[] buf)
		{
			output.Write (buf, 0, buf.Length);
		}
	}

	public class B2OutputEncrypt : B2Output
	{
		public byte encrypt;
		
		public B2OutputEncrypt (Stream output2): base(output2)
		{
			this.encrypt = (byte)(DateTime.Now.Ticks & 0xFF);
			base.write (encrypt);
		}
		
		public B2OutputEncrypt (Stream output2, byte encrypt) : base(output2)
		{
			this.encrypt = encrypt;
			base.write (encrypt);
		}
		
		public override void write (int b)
		{
			b = b ^ encrypt;
			base.write (b);
		}
		
	}

	/// <summary>
	/// B2 serial.
	/// </summary>
	public abstract class B2Serial
	{
		// null
		public const int TYPE_NULL = 0;
		// bool
		public const int TYPE_BOOLEAN_TRUE = 1;
		public const int TYPE_BOOLEAN_FALSE = 2;
		// byte
		public const int TYPE_BYTE_0 = 3;
		public const int TYPE_BYTE = 4;
		// short
		public const int TYPE_SHORT_0 = 5;
		public const int TYPE_SHORT_8B = 6;
		public const int TYPE_SHORT_16B = 7;
		// int b32 b24 b16 b8
		public const int TYPE_INT_0 = 8;
		public const int TYPE_INT_8B = 9;
		public const int TYPE_INT_16B = 10;
		public const int TYPE_INT_32B = 11;
		public const int TYPE_INT_N1 = 12;
		public const int TYPE_INT_1 = 13;
		public const int TYPE_INT_2 = 14;
		public const int TYPE_INT_3 = 15;
		public const int TYPE_INT_4 = 16;
		public const int TYPE_INT_5 = 17;
		public const int TYPE_INT_6 = 18;
		public const int TYPE_INT_7 = 19;
		public const int TYPE_INT_8 = 20;
		public const int TYPE_INT_9 = 21;
		public const int TYPE_INT_10 = 22;
		public const int TYPE_INT_11 = 23;
		public const int TYPE_INT_12 = 24;
		public const int TYPE_INT_13 = 25;
		public const int TYPE_INT_14 = 26;
		public const int TYPE_INT_15 = 27;
		public const int TYPE_INT_16 = 28;
		public const int TYPE_INT_17 = 29;
		public const int TYPE_INT_18 = 30;
		public const int TYPE_INT_19 = 31;
		public const int TYPE_INT_20 = 32;
		public const int TYPE_INT_21 = 33;
		public const int TYPE_INT_22 = 34;
		public const int TYPE_INT_23 = 35;
		public const int TYPE_INT_24 = 36;
		public const int TYPE_INT_25 = 37;
		public const int TYPE_INT_26 = 38;
		public const int TYPE_INT_27 = 39;
		public const int TYPE_INT_28 = 40;
		public const int TYPE_INT_29 = 41;
		public const int TYPE_INT_30 = 42;
		public const int TYPE_INT_31 = 43;
		public const int TYPE_INT_32 = 44;
		// long b64 b56 b48 b40 b32 b24 b16 b8
		public const int TYPE_LONG_0 = 45;
		public const int TYPE_LONG_8B = 46;
		public const int TYPE_LONG_16B = 47;
		public const int TYPE_LONG_32B = 48;
		public const int TYPE_LONG_64B = 49;
		// double b64 b56 b48 b40 b32 b24 b16 b8
		public const int TYPE_DOUBLE_0 = 50;
		// public const int DOUBLE_8B = 51;
		// public const int DOUBLE_16B = 52;
		// public const int DOUBLE_32B = 53;
		public const int TYPE_DOUBLE_64B = 54;
		// STR [bytes]
		public const int TYPE_STR_0 = 55;
		public const int TYPE_STR = 56;
		public const int TYPE_STR_1 = 57;
		public const int TYPE_STR_2 = 58;
		public const int TYPE_STR_3 = 59;
		public const int TYPE_STR_4 = 60;
		public const int TYPE_STR_5 = 61;
		public const int TYPE_STR_6 = 62;
		public const int TYPE_STR_7 = 63;
		public const int TYPE_STR_8 = 64;
		public const int TYPE_STR_9 = 65;
		public const int TYPE_STR_10 = 66;
		public const int TYPE_STR_11 = 67;
		public const int TYPE_STR_12 = 68;
		public const int TYPE_STR_13 = 69;
		public const int TYPE_STR_14 = 70;
		public const int TYPE_STR_15 = 71;
		public const int TYPE_STR_16 = 72;
		public const int TYPE_STR_17 = 73;
		public const int TYPE_STR_18 = 74;
		public const int TYPE_STR_19 = 75;
		public const int TYPE_STR_20 = 76;
		public const int TYPE_STR_21 = 77;
		public const int TYPE_STR_22 = 78;
		public const int TYPE_STR_23 = 79;
		public const int TYPE_STR_24 = 80;
		public const int TYPE_STR_25 = 81;
		public const int TYPE_STR_26 = 82;
		// Bytes [int len, byte[]]
		public const int TYPE_BYTES_0 = 83;
		public const int TYPE_BYTES = 84;
		// VECTOR [int len, v...]
		public const int TYPE_VECTOR_0 = 85;
		public const int TYPE_VECTOR = 86;
		public const int TYPE_VECTOR_1 = 87;
		public const int TYPE_VECTOR_2 = 88;
		public const int TYPE_VECTOR_3 = 89;
		public const int TYPE_VECTOR_4 = 90;
		public const int TYPE_VECTOR_5 = 91;
		public const int TYPE_VECTOR_6 = 92;
		public const int TYPE_VECTOR_7 = 93;
		public const int TYPE_VECTOR_8 = 94;
		public const int TYPE_VECTOR_9 = 95;
		public const int TYPE_VECTOR_10 = 96;
		public const int TYPE_VECTOR_11 = 97;
		public const int TYPE_VECTOR_12 = 98;
		public const int TYPE_VECTOR_13 = 99;
		public const int TYPE_VECTOR_14 = 100;
		public const int TYPE_VECTOR_15 = 101;
		public const int TYPE_VECTOR_16 = 102;
		public const int TYPE_VECTOR_17 = 103;
		public const int TYPE_VECTOR_18 = 104;
		public const int TYPE_VECTOR_19 = 105;
		public const int TYPE_VECTOR_20 = 106;
		public const int TYPE_VECTOR_21 = 107;
		public const int TYPE_VECTOR_22 = 108;
		public const int TYPE_VECTOR_23 = 109;
		public const int TYPE_VECTOR_24 = 110;
		// HASHTABLE [int len, k,v...]
		public const int TYPE_HASHTABLE_0 = 111;
		public const int TYPE_HASHTABLE = 112;
		public const int TYPE_HASHTABLE_1 = 113;
		public const int TYPE_HASHTABLE_2 = 114;
		public const int TYPE_HASHTABLE_3 = 115;
		public const int TYPE_HASHTABLE_4 = 116;
		public const int TYPE_HASHTABLE_5 = 117;
		public const int TYPE_HASHTABLE_6 = 118;
		public const int TYPE_HASHTABLE_7 = 119;
		public const int TYPE_HASHTABLE_8 = 120;
		public const int TYPE_HASHTABLE_9 = 121;
		public const int TYPE_HASHTABLE_10 = 122;
		public const int TYPE_HASHTABLE_11 = 123;
		public const int TYPE_HASHTABLE_12 = 124;
		public const int TYPE_HASHTABLE_13 = 125;
		public const int TYPE_HASHTABLE_14 = 126;
		public const int TYPE_HASHTABLE_15 = 127;

		// java.util.Date
		public const int JAVA_DATE = -31;
		
		public const int JAVA_OBJECT = -32;
		//b2int
		public const int TYPE_INT_B2 = -33;
		// ///////////////////////////
		
		public static void writeNull (B2Output output)
		{
			output.write (TYPE_NULL);
		}
		
		// ////////////////////////////
		public static bool readBool (B2Input input)
		{
			int v = input.read ();
			if (v == TYPE_BOOLEAN_TRUE)
				return true;
			else if (v == TYPE_BOOLEAN_FALSE)
				return false;
			
			if (v == -1)
				throw new SocketException (-1);
			else
				throw new IOException ("unknow type: " + v);
		}
		
		public static void writeBool (B2Output output, bool v)
		{
			if (v)
				output.write (TYPE_BOOLEAN_TRUE);
			else
				output.write (TYPE_BOOLEAN_FALSE);
		}
		
		// ////////////////////////////
		public static byte readByte (B2Input input)
		{
			int v = input.read ();
			if (v == TYPE_BYTE_0)
				return 0;
			else if (v == TYPE_BYTE)
				return (byte)input.read ();
			
			if (v == -1)
				throw new SocketException (-1);
			else
				throw new IOException ("unknow type: " + v);
		}
		
		public static void writeByte (B2Output output, int v)
		{
			if (v == 0)
				output.write (TYPE_BYTE_0);
			else {
				output.write (TYPE_BYTE);
				output.write (v);
			}
		}
		
		// ////////////////////////////
		public static short readShort (B2Input input)
		{
			int v = input.read ();
			if (v == TYPE_SHORT_0)
				return 0;
			else if (v == TYPE_SHORT_8B)
				return (short)input.read ();
			else if (v == TYPE_SHORT_16B)
				return (short)(((input.read () & 0xff) << 8) + ((input.read () & 0xff) << 0));
			
			if (v == -1)
				throw new SocketException (-1);
			else
				throw new IOException ("unknow type: " + v);
		}
		
		public static void writeShort (B2Output output, int v)
		{
			if (v == 0)
				output.write (TYPE_SHORT_0);
			else if (v >= sbyte.MinValue && v <= sbyte.MaxValue) {
				output.write (TYPE_SHORT_8B);
				output.write (v);
			} else {
				output.write (TYPE_SHORT_16B);
				output.write ((byte)((v >> 8) & 0xff));
				output.write ((byte)((v >> 0) & 0xff));
			}
		}
		
		// ////////////////////////////
		public static int readInt (B2Input input)
		{
			int v = input.read ();
			switch (v) {
			case TYPE_INT_N1:
				return -1;
			case TYPE_INT_0:
				return 0;
			case TYPE_INT_1:
				return 1;
			case TYPE_INT_2:
				return 2;
			case TYPE_INT_3:
				return 3;
			case TYPE_INT_4:
				return 4;
			case TYPE_INT_5:
				return 5;
			case TYPE_INT_6:
				return 6;
			case TYPE_INT_7:
				return 7;
			case TYPE_INT_8:
				return 8;
			case TYPE_INT_9:
				return 9;
			case TYPE_INT_10:
				return 10;
			case TYPE_INT_11:
				return 11;
			case TYPE_INT_12:
				return 12;
			case TYPE_INT_13:
				return 13;
			case TYPE_INT_14:
				return 14;
			case TYPE_INT_15:
				return 15;
			case TYPE_INT_16:
				return 16;
			case TYPE_INT_17:
				return 17;
			case TYPE_INT_18:
				return 18;
			case TYPE_INT_19:
				return 19;
			case TYPE_INT_20:
				return 20;
			case TYPE_INT_21:
				return 21;
			case TYPE_INT_22:
				return 22;
			case TYPE_INT_23:
				return 23;
			case TYPE_INT_24:
				return 24;
			case TYPE_INT_25:
				return 25;
			case TYPE_INT_26:
				return 26;
			case TYPE_INT_27:
				return 27;
			case TYPE_INT_28:
				return 28;
			case TYPE_INT_29:
				return 29;
			case TYPE_INT_30:
				return 30;
			case TYPE_INT_31:
				return 31;
			case TYPE_INT_32:
				return 32;
			case TYPE_INT_8B:
				return (sbyte)input.read ();
			case TYPE_INT_16B:
				return (short)(((input.read () & 0xff) << 8) + ((input.read () & 0xff) << 0));
			case TYPE_INT_32B:
				return ((input.read () & 0xff) << 24) + ((input.read () & 0xff) << 16)
					+ ((input.read () & 0xff) << 8) + ((input.read () & 0xff) << 0);
			}
			
			if (v == -1)
				throw new SocketException (-1);
			else
				throw new IOException ("unknow type: " + v);
		}
		
		public static void writeInt (B2Output output, int v)
		{
			switch (v) {
			case -1:
				output.write (TYPE_INT_N1);
				break;
			case 0:
				output.write (TYPE_INT_0);
				break;
			case 1:
				output.write (TYPE_INT_1);
				break;
			case 2:
				output.write (TYPE_INT_2);
				break;
			case 3:
				output.write (TYPE_INT_3);
				break;
			case 4:
				output.write (TYPE_INT_4);
				break;
			case 5:
				output.write (TYPE_INT_5);
				break;
			case 6:
				output.write (TYPE_INT_6);
				break;
			case 7:
				output.write (TYPE_INT_7);
				break;
			case 8:
				output.write (TYPE_INT_8);
				break;
			case 9:
				output.write (TYPE_INT_9);
				break;
			case 10:
				output.write (TYPE_INT_10);
				break;
			case 11:
				output.write (TYPE_INT_11);
				break;
			case 12:
				output.write (TYPE_INT_12);
				break;
			case 13:
				output.write (TYPE_INT_13);
				break;
			case 14:
				output.write (TYPE_INT_14);
				break;
			case 15:
				output.write (TYPE_INT_15);
				break;
			case 16:
				output.write (TYPE_INT_16);
				break;
			case 17:
				output.write (TYPE_INT_17);
				break;
			case 18:
				output.write (TYPE_INT_18);
				break;
			case 19:
				output.write (TYPE_INT_19);
				break;
			case 20:
				output.write (TYPE_INT_20);
				break;
			case 21:
				output.write (TYPE_INT_21);
				break;
			case 22:
				output.write (TYPE_INT_22);
				break;
			case 23:
				output.write (TYPE_INT_23);
				break;
			case 24:
				output.write (TYPE_INT_24);
				break;
			case 25:
				output.write (TYPE_INT_25);
				break;
			case 26:
				output.write (TYPE_INT_26);
				break;
			case 27:
				output.write (TYPE_INT_27);
				break;
			case 28:
				output.write (TYPE_INT_28);
				break;
			case 29:
				output.write (TYPE_INT_29);
				break;
			case 30:
				output.write (TYPE_INT_30);
				break;
			case 31:
				output.write (TYPE_INT_31);
				break;
			case 32:
				output.write (TYPE_INT_32);
				break;
			default:
				if (v >= sbyte.MinValue && v <= sbyte.MaxValue) {
					output.write (TYPE_INT_8B);
					output.write (v);
				} else if (v >= short.MinValue && v <= short.MaxValue) {
					output.write (TYPE_INT_16B);
					output.write ((byte)((v >> 8) & 0xff));
					output.write ((byte)((v >> 0) & 0xff));
				} else {
					output.write (TYPE_INT_32B);
					output.write ((byte)((v >> 24) & 0xff));
					output.write ((byte)((v >> 16) & 0xff));
					output.write ((byte)((v >> 8) & 0xff));
					output.write ((byte)((v >> 0) & 0xff));
				}
				break;
			}
		}
		
		// ////////////////////////////
		public static long readLong (B2Input input)
		{
			int v = input.read ();
			switch (v) {
			case TYPE_LONG_0:
				return 0;
			case TYPE_LONG_8B:
				return input.read ();
			case TYPE_LONG_16B:
				return (((input.read () & 0xff) << 8) + ((input.read () & 0xff) << 0));
			case TYPE_LONG_32B:
				return ((input.read () & 0xff) << 24) + ((input.read () & 0xff) << 16)
					+ ((input.read () & 0xff) << 8) + ((input.read () & 0xff) << 0);
			case TYPE_LONG_64B:
				byte[] b = new byte[8];
				for (int i = 0; i < 8; i++) {
					b [i] = (byte)input.read ();
				}
				long high = ((b [0] & 0xff) << 24) + ((b [1] & 0xff) << 16)
					+ ((b [2] & 0xff) << 8) + ((b [3] & 0xff) << 0);
				long low = ((b [4] & 0xff) << 24) + ((b [5] & 0xff) << 16)
					+ ((b [6] & 0xff) << 8) + ((b [7] & 0xff) << 0);
				return (high << 32) + (0xffffffffL & low);
			}
			if (v == -1)
				throw new SocketException (-1);
			else
				throw new IOException ("unknow type: " + v);
		}
		
		public static void writeLong (B2Output output, long v)
		{
			if (v == 0) {
				output.write (TYPE_LONG_0);
			} else if (v >= sbyte.MinValue && v <= sbyte.MaxValue) {
				output.write (TYPE_LONG_8B);
				output.write ((int)v);
			} else if (v >= short.MinValue && v <= short.MaxValue) {
				output.write (TYPE_LONG_16B);
				output.write ((byte)((v >> 8) & 0xff));
				output.write ((byte)((v >> 0) & 0xff));
			} else if (v >= int.MinValue && v <= int.MaxValue) {
				output.write (TYPE_LONG_32B);
				output.write ((byte)((v >> 24) & 0xff));
				output.write ((byte)((v >> 16) & 0xff));
				output.write ((byte)((v >> 8) & 0xff));
				output.write ((byte)((v >> 0) & 0xff));
			} else {
				output.write (TYPE_LONG_64B);
				output.write ((byte)((v >> 56) & 0xff));
				output.write ((byte)((v >> 48) & 0xff));
				output.write ((byte)((v >> 40) & 0xff));
				output.write ((byte)((v >> 32) & 0xff));
				output.write ((byte)((v >> 24) & 0xff));
				output.write ((byte)((v >> 16) & 0xff));
				output.write ((byte)((v >> 8) & 0xff));
				output.write ((byte)((v >> 0) & 0xff));
			}
		}
		
		// ////////////////////////////
		public static double readDouble (B2Input input)
		{
			int v = input.read ();
			switch (v) {
			case TYPE_DOUBLE_0:
				{
					return 0.0;
				}
			case TYPE_DOUBLE_64B:
				{
					byte[] b = new byte[8];
					for (int i = 0; i < 8; i++) {
						b [i] = (byte)input.read ();
					}
					long high = ((b [0] & 0xff) << 24) + ((b [1] & 0xff) << 16)
						+ ((b [2] & 0xff) << 8) + ((b [3] & 0xff) << 0);
					long low = ((b [4] & 0xff) << 24) + ((b [5] & 0xff) << 16)
						+ ((b [6] & 0xff) << 8) + ((b [7] & 0xff) << 0);
					long x = (high << 32) + (0xffffffffL & low);
					//return Double.longBitsToDouble(x);
					return BitConverter.Int64BitsToDouble (x);
				}
			}
			
			if (v == -1)
				throw new SocketException (-1);
			else
				throw new IOException ("unknow type: " + v);
		}
		
		public static void writeDouble (B2Output output, double var)
		{
			//long v = Double.doubleToLongBits(var);
			long v = BitConverter.DoubleToInt64Bits (var);
			if (v == 0) {
				output.write (TYPE_DOUBLE_0);
				// } else if (v >= Byte.MIN_VALUE && v <= Byte.MAX_VALUE) {
				// output.write(DOUBLE_8B);
				// output.write((int) v);
				// } else if (v >= Short.MIN_VALUE && v <= Short.MAX_VALUE) {
				// output.write(DOUBLE_16B);
				// output.write((byte) ((v >> 8) & 0xff));
				// output.write((byte) ((v >> 0) & 0xff));
				// } else if (v >= Integer.MIN_VALUE && v <= Integer.MAX_VALUE) {
				// output.write(DOUBLE_32B);
				// output.write((byte) ((v >> 24) & 0xff));
				// output.write((byte) ((v >> 16) & 0xff));
				// output.write((byte) ((v >> 8) & 0xff));
				// output.write((byte) ((v >> 0) & 0xff));
			} else {
				output.write (TYPE_DOUBLE_64B);
				output.write ((byte)((v >> 56) & 0xff));
				output.write ((byte)((v >> 48) & 0xff));
				output.write ((byte)((v >> 40) & 0xff));
				output.write ((byte)((v >> 32) & 0xff));
				output.write ((byte)((v >> 24) & 0xff));
				output.write ((byte)((v >> 16) & 0xff));
				output.write ((byte)((v >> 8) & 0xff));
				output.write ((byte)((v >> 0) & 0xff));
			}
		}
		
		public static String readString (B2Input input)
		{
			int v = input.read ();
			switch (v) {
			case TYPE_NULL:
				return null;
			case TYPE_STR_0:
				return "";
			case TYPE_STR_1:
				return readStringImpl (input, 1);
			case TYPE_STR_2:
				return readStringImpl (input, 2);
			case TYPE_STR_3:
				return readStringImpl (input, 3);
			case TYPE_STR_4:
				return readStringImpl (input, 4);
			case TYPE_STR_5:
				return readStringImpl (input, 5);
			case TYPE_STR_6:
				return readStringImpl (input, 6);
			case TYPE_STR_7:
				return readStringImpl (input, 7);
			case TYPE_STR_8:
				return readStringImpl (input, 8);
			case TYPE_STR_9:
				return readStringImpl (input, 9);
			case TYPE_STR_10:
				return readStringImpl (input, 10);
			case TYPE_STR_11:
				return readStringImpl (input, 11);
			case TYPE_STR_12:
				return readStringImpl (input, 12);
			case TYPE_STR_13:
				return readStringImpl (input, 13);
			case TYPE_STR_14:
				return readStringImpl (input, 14);
			case TYPE_STR_15:
				return readStringImpl (input, 15);
			case TYPE_STR_16:
				return readStringImpl (input, 16);
			case TYPE_STR_17:
				return readStringImpl (input, 17);
			case TYPE_STR_18:
				return readStringImpl (input, 18);
			case TYPE_STR_19:
				return readStringImpl (input, 19);
			case TYPE_STR_20:
				return readStringImpl (input, 20);
			case TYPE_STR_21:
				return readStringImpl (input, 21);
			case TYPE_STR_22:
				return readStringImpl (input, 22);
			case TYPE_STR_23:
				return readStringImpl (input, 23);
			case TYPE_STR_24:
				return readStringImpl (input, 24);
			case TYPE_STR_25:
				return readStringImpl (input, 25);
			case TYPE_STR_26:
				return readStringImpl (input, 26);
			case TYPE_STR:
				int len = readInt (input);
				return readStringImpl (input, len);
			}
			if (v == -1)
				throw new SocketException (-1);
			else
				throw new IOException ("unknow type: " + v);
		}
		
		public static void writeString (B2Output output, String v)
		{
			if (v == null) {
				writeNull (output);
			} else {
				//byte[] b = v.getBytes(UTF8);
				byte[] b = Encoding.UTF8.GetBytes (v);
				int len = b.Length;
				switch (len) {
				case 0:
					output.write (TYPE_STR_0);
					break;
				case 1:
					output.write (TYPE_STR_1);
					printString (output, b);
					break;
				case 2:
					output.write (TYPE_STR_2);
					printString (output, b);
					break;
				case 3:
					output.write (TYPE_STR_3);
					printString (output, b);
					break;
				case 4:
					output.write (TYPE_STR_4);
					printString (output, b);
					break;
				case 5:
					output.write (TYPE_STR_5);
					printString (output, b);
					break;
				case 6:
					output.write (TYPE_STR_6);
					printString (output, b);
					break;
				case 7:
					output.write (TYPE_STR_7);
					printString (output, b);
					break;
				case 8:
					output.write (TYPE_STR_8);
					printString (output, b);
					break;
				case 9:
					output.write (TYPE_STR_9);
					printString (output, b);
					break;
				case 10:
					output.write (TYPE_STR_10);
					printString (output, b);
					break;
				case 11:
					output.write (TYPE_STR_11);
					printString (output, b);
					break;
				case 12:
					output.write (TYPE_STR_12);
					printString (output, b);
					break;
				case 13:
					output.write (TYPE_STR_13);
					printString (output, b);
					break;
				case 14:
					output.write (TYPE_STR_14);
					printString (output, b);
					break;
				case 15:
					output.write (TYPE_STR_15);
					printString (output, b);
					break;
				case 16:
					output.write (TYPE_STR_16);
					printString (output, b);
					break;
				case 17:
					output.write (TYPE_STR_17);
					printString (output, b);
					break;
				case 18:
					output.write (TYPE_STR_18);
					printString (output, b);
					break;
				case 19:
					output.write (TYPE_STR_19);
					printString (output, b);
					break;
				case 20:
					output.write (TYPE_STR_20);
					printString (output, b);
					break;
				case 21:
					output.write (TYPE_STR_21);
					printString (output, b);
					break;
				case 22:
					output.write (TYPE_STR_22);
					printString (output, b);
					break;
				case 23:
					output.write (TYPE_STR_23);
					printString (output, b);
					break;
				case 24:
					output.write (TYPE_STR_24);
					printString (output, b);
					break;
				case 25:
					output.write (TYPE_STR_25);
					printString (output, b);
					break;
				case 26:
					output.write (TYPE_STR_26);
					printString (output, b);
					break;
				default:
					output.write (TYPE_STR);
					writeInt (output, len);
					printString (output, b);
					break;
				}
			}
		}
		
		public static DateTime readDate (B2Input input)
		{
			int v = (sbyte)input.read ();
			if (v == TYPE_NULL)
				return new DateTime ();
			else if (v == JAVA_DATE) {
				byte[] b = new byte[8];
				for (int i = 0; i < 8; i++) {
					b [i] = (byte)input.read ();
				}
				long high = ((b [0] & 0xff) << 24) + ((b [1] & 0xff) << 16)
					+ ((b [2] & 0xff) << 8) + ((b [3] & 0xff) << 0);
				long low = ((b [4] & 0xff) << 24) + ((b [5] & 0xff) << 16)
					+ ((b [6] & 0xff) << 8) + ((b [7] & 0xff) << 0);
				long x = (high << 32) + (0xffffffffL & low);
				long tm = (x + dat0.Ticks / 10000) * 10000;
				return new DateTime (tm);
			}
			
			if (v == -1)
				throw new SocketException (-1);
			else
				throw new IOException ("unknow type: " + v);
		}

		static DateTime dat0 = new DateTime (1970, 1, 2);

		public static void writeDate (B2Output output, DateTime dat)
		{
			long v = (dat.Ticks - dat0.Ticks) / 10000;
			//long v = dat.getTime();
			output.write (JAVA_DATE);
			output.write ((byte)((v >> 56) & 0xff));
			output.write ((byte)((v >> 48) & 0xff));
			output.write ((byte)((v >> 40) & 0xff));
			output.write ((byte)((v >> 32) & 0xff));
			output.write ((byte)((v >> 24) & 0xff));
			output.write ((byte)((v >> 16) & 0xff));
			output.write ((byte)((v >> 8) & 0xff));
			output.write ((byte)((v >> 0) & 0xff));
		}
		
		public static byte[] readBytes (B2Input input)
		{
			int v = input.read ();
			switch (v) {
			case TYPE_NULL:
				{
					return null;
				}
			case TYPE_BYTES_0:
				{
					return new byte[0];
				}
			case TYPE_BYTES:
				{
					int len = readInt (input);
					byte[] b = new byte[len];
					int len2 = input.read (b);
					if (len != len2)
						throw new IOException ("bytes not enough");
					return b;
				}
			}
			if (v == -1)
				throw new SocketException (-1);
			else
				throw new IOException ("unknow type: " + v);
		}
		
		public static void writeBytes (B2Output output, byte[] v)
		{
			if (v == null) {
				writeNull (output);
			} else {
				int len = v.Length;
				if (len == 0) {
					output.write (TYPE_BYTES_0);
				} else {
					output.write (TYPE_BYTES);
					writeInt (output, len);
					output.write (v);
				}
			}
		}
		
		public static ArrayList readList (B2Input input, object o1)
		{
			int v = input.read ();
			switch (v) {
			case TYPE_NULL:
				return null;
			case TYPE_VECTOR_0:
				return new ArrayList ();
			case TYPE_VECTOR_1:
				return readList (input, 1, o1);
			case TYPE_VECTOR_2:
				return readList (input, 2, o1);
			case TYPE_VECTOR_3:
				return readList (input, 3, o1);
			case TYPE_VECTOR_4:
				return readList (input, 4, o1);
			case TYPE_VECTOR_5:
				return readList (input, 5, o1);
			case TYPE_VECTOR_6:
				return readList (input, 6, o1);
			case TYPE_VECTOR_7:
				return readList (input, 7, o1);
			case TYPE_VECTOR_8:
				return readList (input, 8, o1);
			case TYPE_VECTOR_9:
				return readList (input, 9, o1);
			case TYPE_VECTOR_10:
				return readList (input, 10, o1);
			case TYPE_VECTOR_11:
				return readList (input, 11, o1);
			case TYPE_VECTOR_12:
				return readList (input, 12, o1);
			case TYPE_VECTOR_13:
				return readList (input, 13, o1);
			case TYPE_VECTOR_14:
				return readList (input, 14, o1);
			case TYPE_VECTOR_15:
				return readList (input, 15, o1);
			case TYPE_VECTOR_16:
				return readList (input, 16, o1);
			case TYPE_VECTOR_17:
				return readList (input, 17, o1);
			case TYPE_VECTOR_18:
				return readList (input, 18, o1);
			case TYPE_VECTOR_19:
				return readList (input, 19, o1);
			case TYPE_VECTOR_20:
				return readList (input, 20, o1);
			case TYPE_VECTOR_21:
				return readList (input, 21, o1);
			case TYPE_VECTOR_22:
				return readList (input, 22, o1);
			case TYPE_VECTOR_23:
				return readList (input, 23, o1);
			case TYPE_VECTOR_24:
				return readList (input, 24, o1);
			case TYPE_VECTOR:
				int len = readInt (input);
				return readList (input, len, o1);
			}
			
			if (v == -1)
				throw new SocketException (-1);
			else
				throw new IOException ("unknow type: " + v);
		}
		
		private static ArrayList readList (B2Input input, int len, object o1)
		{
			ArrayList ret = new ArrayList (len);
			for (int i = 0; i < len; i++) {
				//B2Serial obj = (B2Serial)Activator.CreateInstance (c1);
				//obj.readObject (input);
				object obj = readObj (input, o1);
				ret.Add (obj);
			}
			return ret;
		}

		public static void writeMap (B2Output output, Hashtable v)
		{
			if (v == null) {
				writeNull (output);
			} else {
				int len = v.Count;
				switch (len) {
				case 0:
					output.write (TYPE_HASHTABLE_0);
					break;
				case 1:
					output.write (TYPE_HASHTABLE_1);
					break;
				case 2:
					output.write (TYPE_HASHTABLE_2);
					break;
				case 3:
					output.write (TYPE_HASHTABLE_3);
					break;
				case 4:
					output.write (TYPE_HASHTABLE_4);
					break;
				case 5:
					output.write (TYPE_HASHTABLE_5);
					break;
				case 6:
					output.write (TYPE_HASHTABLE_6);
					break;
				case 7:
					output.write (TYPE_HASHTABLE_7);
					break;
				case 8:
					output.write (TYPE_HASHTABLE_8);
					break;
				case 9:
					output.write (TYPE_HASHTABLE_9);
					break;
				case 10:
					output.write (TYPE_HASHTABLE_10);
					break;
				case 11:
					output.write (TYPE_HASHTABLE_11);
					break;
				case 12:
					output.write (TYPE_HASHTABLE_12);
					break;
				case 13:
					output.write (TYPE_HASHTABLE_13);
					break;
				case 14:
					output.write (TYPE_HASHTABLE_14);
					break;
				case 15:
					output.write (TYPE_HASHTABLE_15);
					break;
				default:
					output.write (TYPE_HASHTABLE);
					writeInt (output, len);
					break;
				}
				
				foreach (System.Collections.DictionaryEntry e in v) {
					object key = e.Key;
					object var = e.Value;
					writeObj (output, key);
					writeObj (output, var);
				}
			}
		}

		public static Hashtable readMap (B2Input input, object kType, object vType)
		{
			int tag = (sbyte)input.read ();
			switch (tag) {
			case TYPE_NULL:
				return null;
			case TYPE_HASHTABLE_0:
				return new Hashtable ();
			case TYPE_HASHTABLE_1:
				return readMap (input, 1, kType, vType);
			case TYPE_HASHTABLE_2:
				return readMap (input, 2, kType, vType);
			case TYPE_HASHTABLE_3:
				return readMap (input, 3, kType, vType);
			case TYPE_HASHTABLE_4:
				return readMap (input, 4, kType, vType);
			case TYPE_HASHTABLE_5:
				return readMap (input, 5, kType, vType);
			case TYPE_HASHTABLE_6:
				return readMap (input, 6, kType, vType);
			case TYPE_HASHTABLE_7:
				return readMap (input, 7, kType, vType);
			case TYPE_HASHTABLE_8:
				return readMap (input, 8, kType, vType);
			case TYPE_HASHTABLE_9:
				return readMap (input, 9, kType, vType);
			case TYPE_HASHTABLE_10:
				return readMap (input, 10, kType, vType);
			case TYPE_HASHTABLE_11:
				return readMap (input, 11, kType, vType);
			case TYPE_HASHTABLE_12:
				return readMap (input, 12, kType, vType);
			case TYPE_HASHTABLE_13:
				return readMap (input, 13, kType, vType);
			case TYPE_HASHTABLE_14:
				return readMap (input, 14, kType, vType);
			case TYPE_HASHTABLE_15:
				return readMap (input, 15, kType, vType);
			case TYPE_HASHTABLE:
				int len = readInt (input);
				return readMap (input, len, kType, vType);
			}
			if (tag == -1)
				throw new SocketException (-1);
			else
				throw new IOException ("unknow type: " + tag);
		}
		
		private static Hashtable readMap (B2Input input, int len, object kType,
		                                 object vType)
		{
			Hashtable ret = new Hashtable ();
			for (int i = 0; i < len; i++) {
				object key = readObj (input, kType);
				object var = readObj (input, vType);
				ret [key] = var;
			}
			return ret;
		}

		private static object readObj (B2Input input, object o1)
		{
			//Type c1 = typeof(o1);

			if (o1 is int || o1 is Int32 || o1 is UInt32) {
				return readInt (input);
			} else if (o1 is string) {
				return readString (input);
			} else if (o1 is bool || o1 is Boolean) {
				return readBool (input);
			} else if (o1 is byte || o1 is Byte || o1 is SByte) {
				return readByte (input);
			} else if (o1 is byte[]) {
				return readBytes (input);
			} else if (o1 is short || o1 is Int16 || o1 is UInt16) {
				return readShort (input);
			} else if (o1 is long || o1 is Int64 || o1 is UInt64) {
				return readLong (input);
			} else if (o1 is DateTime) {
				return readDate (input);
			} else if (o1 is ArrayList) {
				return readList (input, o1);
			} else if (o1 is double || o1 is Double) {
				return readDouble (input);
			} else if (o1 is B2Serial) {
				B2Serial obj = (B2Serial)Activator.CreateInstance (o1.GetType ());
				obj.readObject (input);
				return obj;
			} else {
				throw new IOException ("unknow tag error:" + o1);
			}
		}

		private static void writeObj (B2Output output, object obj)
		{
			if (obj == null) {
				writeNull (output);
			} else if (obj is int || obj is Int32 || obj is UInt32) {
				int v = (int)obj;
				writeInt (output, v);
			} else if (obj is string) {
				String v = (string)obj;
				writeString (output, v);
			} else if (obj is bool || obj is Boolean) {
				bool v = (bool)obj;
				writeBool (output, v);
			} else if (obj is byte || obj is Byte) {
				int v = (byte)obj;
				writeByte (output, v);
			} else if (obj is byte[]) {
				byte[] v = (byte[])obj;
				writeBytes (output, v);
			} else if (obj is ArrayList) {
				ArrayList v = (ArrayList)obj;
				writeList (output, v);
			} else if (obj is Hashtable) {
				Hashtable v = (Hashtable)obj;
				writeMap (output, v);
			} else if (obj is short || obj is Int16 || obj is UInt16) {
				int v = (short)obj;
				writeShort (output, v);
			} else if (obj is long || obj is Int64 || obj is UInt64) {
				long v = (long)obj;
				writeLong (output, v);
			} else if (obj is double || obj is Double) {
				double v = (double)obj;
				writeDouble (output, v);
			} else if (obj is DateTime) {
				DateTime v = (DateTime)obj;
				writeDate (output, v);
			} else if (obj is B2Serial) {
				B2Serial v = (B2Serial)obj;
				v.writeObject (output);
			} else {
				throw new IOException ("unsupported object:" + obj);
			}
		}

		public static void writeList (B2Output output, ArrayList v)
		{
			if (v == null) {
				writeNull (output);
			} else {
				int len = v.Count;
				switch (len) {
				case 0:
					output.write (TYPE_VECTOR_0);
					break;
				case 1:
					output.write (TYPE_VECTOR_1);
					break;
				case 2:
					output.write (TYPE_VECTOR_2);
					break;
				case 3:
					output.write (TYPE_VECTOR_3);
					break;
				case 4:
					output.write (TYPE_VECTOR_4);
					break;
				case 5:
					output.write (TYPE_VECTOR_5);
					break;
				case 6:
					output.write (TYPE_VECTOR_6);
					break;
				case 7:
					output.write (TYPE_VECTOR_7);
					break;
				case 8:
					output.write (TYPE_VECTOR_8);
					break;
				case 9:
					output.write (TYPE_VECTOR_9);
					break;
				case 10:
					output.write (TYPE_VECTOR_10);
					break;
				case 11:
					output.write (TYPE_VECTOR_11);
					break;
				case 12:
					output.write (TYPE_VECTOR_12);
					break;
				case 13:
					output.write (TYPE_VECTOR_13);
					break;
				case 14:
					output.write (TYPE_VECTOR_14);
					break;
				case 15:
					output.write (TYPE_VECTOR_15);
					break;
				case 16:
					output.write (TYPE_VECTOR_16);
					break;
				case 17:
					output.write (TYPE_VECTOR_17);
					break;
				case 18:
					output.write (TYPE_VECTOR_18);
					break;
				case 19:
					output.write (TYPE_VECTOR_19);
					break;
				case 20:
					output.write (TYPE_VECTOR_20);
					break;
				case 21:
					output.write (TYPE_VECTOR_21);
					break;
				case 22:
					output.write (TYPE_VECTOR_22);
					break;
				case 23:
					output.write (TYPE_VECTOR_23);
					break;
				case 24:
					output.write (TYPE_VECTOR_24);
					break;
				default:
					output.write (TYPE_VECTOR);
					writeInt (output, len);
					break;
				}
				
				for (int i = 0; i < len; i++) {
					object obj = v [i];
					//B2Serial obj = (B2Serial)v [i];
					//obj.writeObject (output);
					writeObj (output, obj);
				}
			}
		}
		
		protected static String readStringImpl (B2Input input, int length)
		{
			if (length <= 0)
				return "";
			
			byte[] b = new byte[length];
			int len2 = input.read (b);
			if (length != len2) {
				throw new IOException ("bytes not enough");
			}
			
			return Encoding.UTF8.GetString (b);
		}
		
		protected static void printString (B2Output output, byte[] v)
		{
			output.write (v);
		}

		// ///////////////////////////
		public const bool boolVal = true;
		public const sbyte byteVal = 0;
		public const short shortVal = 0;
		public const int intVal = 0;
		public const long longVal = 0;
		public const double doubleVal = 0;
		public const string stringVal = "";
		public static byte[] bytesVal = new byte[1];
		public static DateTime dateVal = DateTime.Now;
		
		// ///////////////////////////
		
		public abstract void writeObject (B2Output output) ;
		
		public abstract void readObject (B2Input input) ;

		public void writeObject (MemoryStream output)
		{
			B2Output _out = new B2Output (output);
			writeObject (_out);
		}
	
		public byte[] toByteArray ()
		{
			MemoryStream stream = new MemoryStream ();
			writeObject (stream);
			return stream.ToArray ();
		}
	
		public void readObject (byte[] buff)
		{
			B2Input _in = new B2Input (buff);
			readObject (_in);
		}

		public void readObject (MemoryStream input)
		{
			B2Input _in = new B2Input (input);
			readObject (_in);
		}

	}
}

