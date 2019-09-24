﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.UnitTests
{
	public class LargeSwitchTest
	{
		#region LargeSwitchFixture test

		[MosaUnitTest(Series = "I4")]
		public static int LargeSwitchTest1(int a)
		{
			switch (a)
			{
				case 1: return 3;
				case 2: return 6;
				case 3: return 9;
				case 4: return 12;
				case 5: return 15;
				case 6: return 18;
				case 7: return 21;
				case 8: return 24;
				case 9: return 27;
				case 10: return 30;
				case 11: return 33;
				case 12: return 36;
				case 13: return 39;
				case 14: return 42;
				case 15: return 45;
				case 16: return 48;
				case 17: return 51;
				case 18: return 54;
				case 19: return 57;
				case 20: return 60;
				case 21: return 63;
				case 22: return 66;
				case 23: return 69;
				case 24: return 72;
				case 25: return 75;
				case 26: return 78;
				case 27: return 81;
				case 28: return 84;
				case 29: return 87;
				case 30: return 90;
				case 31: return 93;
				case 32: return 96;
				case 33: return 99;
				case 34: return 102;
				case 35: return 105;
				case 36: return 108;
				case 37: return 111;
				case 38: return 114;
				case 39: return 117;
				case 40: return 120;
				case 41: return 123;
				case 42: return 126;
				case 43: return 129;
				case 44: return 132;
				case 45: return 135;
				case 46: return 138;
				case 47: return 141;
				case 48: return 144;
				case 49: return 147;
				case 50: return 150;
				case 51: return 153;
				case 52: return 156;
				case 53: return 159;
				case 54: return 162;
				case 55: return 165;
				case 56: return 168;
				case 57: return 171;
				case 58: return 174;
				case 59: return 177;
				case 60: return 180;
				case 61: return 183;
				case 62: return 186;
				case 63: return 189;
				case 64: return 192;
				case 65: return 195;
				case 66: return 198;
				case 67: return 201;
				case 68: return 204;
				case 69: return 207;
				case 70: return 210;
				case 71: return 213;
				case 72: return 216;
				case 73: return 219;
				case 74: return 222;
				case 75: return 225;
				case 76: return 228;
				case 77: return 231;
				case 78: return 234;
				case 79: return 237;
				case 80: return 240;
				case 81: return 243;
				case 82: return 246;
				case 83: return 249;
				case 84: return 252;
				case 85: return 255;
				case 86: return 258;
				case 87: return 261;
				case 88: return 264;
				case 89: return 267;
				case 90: return 270;
				case 91: return 273;
				case 92: return 276;
				case 93: return 279;
				case 94: return 282;
				case 95: return 285;
				case 96: return 288;
				case 97: return 291;
				case 98: return 294;
				case 99: return 297;
				case 100: return 300;
				case 101: return 303;
				case 102: return 306;
				case 103: return 309;
				case 104: return 312;
				case 105: return 315;
				case 106: return 318;
				case 107: return 321;
				case 108: return 324;
				case 109: return 327;
				case 110: return 330;
				case 111: return 333;
				case 112: return 336;
				case 113: return 339;
				case 114: return 342;
				case 115: return 345;
				case 116: return 348;
				case 117: return 351;
				case 118: return 354;
				case 119: return 357;
				case 120: return 360;
				case 121: return 363;
				case 122: return 366;
				case 123: return 369;
				case 124: return 372;
				case 125: return 375;
				case 126: return 378;
				case 127: return 381;
				case 128: return 384;
				case 129: return 387;
				case 130: return 390;
				case 131: return 393;
				case 132: return 396;
				case 133: return 399;
				case 134: return 402;
				case 135: return 405;
				case 136: return 408;
				case 137: return 411;
				case 138: return 414;
				case 139: return 417;
				case 140: return 420;
				case 141: return 423;
				case 142: return 426;
				case 143: return 429;
				case 144: return 432;
				case 145: return 435;
				case 146: return 438;
				case 147: return 441;
				case 148: return 444;
				case 149: return 447;
				case 150: return 450;
				case 151: return 453;
				case 152: return 456;
				case 153: return 459;
				case 154: return 462;
				case 155: return 465;
				case 156: return 468;
				case 157: return 471;
				case 158: return 474;
				case 159: return 477;
				case 160: return 480;
				case 161: return 483;
				case 162: return 486;
				case 163: return 489;
				case 164: return 492;
				case 165: return 495;
				case 166: return 498;
				case 167: return 501;
				case 168: return 504;
				case 169: return 507;
				case 170: return 510;
				case 171: return 513;
				case 172: return 516;
				case 173: return 519;
				case 174: return 522;
				case 175: return 525;
				case 176: return 528;
				case 177: return 531;
				case 178: return 534;
				case 179: return 537;
				case 180: return 540;
				case 181: return 543;
				case 182: return 546;
				case 183: return 549;
				case 184: return 552;
				case 185: return 555;
				case 186: return 558;
				case 187: return 561;
				case 188: return 564;
				case 189: return 567;
				case 190: return 570;
				case 191: return 573;
				case 192: return 576;
				case 193: return 579;
				case 194: return 582;
				case 195: return 585;
				case 196: return 588;
				case 197: return 591;
				case 198: return 594;
				case 199: return 597;
				case 200: return 600;
				case 201: return 603;
				case 202: return 606;
				case 203: return 609;
				case 204: return 612;
				case 205: return 615;
				case 206: return 618;
				case 207: return 621;
				case 208: return 624;
				case 209: return 627;
				case 210: return 630;
				case 211: return 633;
				case 212: return 636;
				case 213: return 639;
				case 214: return 642;
				case 215: return 645;
				case 216: return 648;
				case 217: return 651;
				case 218: return 654;
				case 219: return 657;
				case 220: return 660;
				case 221: return 663;
				case 222: return 666;
				case 223: return 669;
				case 224: return 672;
				case 225: return 675;
				case 226: return 678;
				case 227: return 681;
				case 228: return 684;
				case 229: return 687;
				case 230: return 690;
				case 231: return 693;
				case 232: return 696;
				case 233: return 699;
				case 234: return 702;
				case 235: return 705;
				case 236: return 708;
				case 237: return 711;
				case 238: return 714;
				case 239: return 717;
				case 240: return 720;
				case 241: return 723;
				case 242: return 726;
				case 243: return 729;
				case 244: return 732;
				case 245: return 735;
				case 246: return 738;
				case 247: return 741;
				case 248: return 744;
				case 249: return 747;
				case 250: return 750;
				case 251: return 753;
				case 252: return 756;
				case 253: return 759;
				case 254: return 762;
				case 255: return 765;
				case 256: return 768;
				case 257: return 771;
				case 258: return 774;
				case 259: return 777;
				case 260: return 780;
				case 261: return 783;
				case 262: return 786;
				case 263: return 789;
				case 264: return 792;
				case 265: return 795;
				case 266: return 798;
				case 267: return 801;
				case 268: return 804;
				case 269: return 807;
				case 270: return 810;
				case 271: return 813;
				case 272: return 816;
				case 273: return 819;
				case 274: return 822;
				case 275: return 825;
				case 276: return 828;
				case 277: return 831;
				case 278: return 834;
				case 279: return 837;
				case 280: return 840;
				case 281: return 843;
				case 282: return 846;
				case 283: return 849;
				case 284: return 852;
				case 285: return 855;
				case 286: return 858;
				case 287: return 861;
				case 288: return 864;
				case 289: return 867;
				case 290: return 870;
				case 291: return 873;
				case 292: return 876;
				case 293: return 879;
				case 294: return 882;
				case 295: return 885;
				case 296: return 888;
				case 297: return 891;
				case 298: return 894;
				case 299: return 897;
				case 300: return 900;
				case 301: return 903;
				case 302: return 906;
				case 303: return 909;
				case 304: return 912;
				case 305: return 915;
				case 306: return 918;
				case 307: return 921;
				case 308: return 924;
				case 309: return 927;
				case 310: return 930;
				case 311: return 933;
				case 312: return 936;
				case 313: return 939;
				case 314: return 942;
				case 315: return 945;
				case 316: return 948;
				case 317: return 951;
				case 318: return 954;
				case 319: return 957;
				case 320: return 960;
				case 321: return 963;
				case 322: return 966;
				case 323: return 969;
				case 324: return 972;
				case 325: return 975;
				case 326: return 978;
				case 327: return 981;
				case 328: return 984;
				case 329: return 987;
				case 330: return 990;
				case 331: return 993;
				case 332: return 996;
				case 333: return 999;
				case 334: return 1002;
				case 335: return 1005;
				case 336: return 1008;
				case 337: return 1011;
				case 338: return 1014;
				case 339: return 1017;
				case 340: return 1020;
				case 341: return 1023;
				case 342: return 1026;
				case 343: return 1029;
				case 344: return 1032;
				case 345: return 1035;
				case 346: return 1038;
				case 347: return 1041;
				default: return a;
			}
		}

		#endregion LargeSwitchFixture test
	}
}
