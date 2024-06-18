sbyte min_sbyte = -128;
sbyte max_sbyte = 127;
Console.WriteLine("sbyte is 8-bits integer datatype with the sign");
Console.WriteLine("Min sbyte: " + min_sbyte);
Console.WriteLine("Max sbyte: " + max_sbyte + "\n");
// sbyte від -128 до 127 (8 бітів, значення від - (2^8 / 2) до (2^8 / 2 - 1))

byte min_byte = 0;
byte max_byte = 255;
Console.WriteLine("byte is 8-bits integer datatype without the sign, can be used to represent chars' numbers in ASCII");
Console.WriteLine("Min byte: " + min_byte);
Console.WriteLine("Max byte: " + max_byte + "\n");
// byte від 0 до 255 (8 бітів, значення від 0 до 2^8 - 1)

short min_short = -32768;
short max_short = 32767;
Console.WriteLine("short is 16-bits integer datatype with the sign");
Console.WriteLine("Min short: " + min_short);
Console.WriteLine("Max short: " + max_short + "\n");
// short від -32,768 до 32,767 (16 бітів, значення від - (2^16 / 2) до (2^16 / 2 - 1))

ushort min_ushort = 0;
ushort max_uhort = 65535;
Console.WriteLine("ushort is 16-bits integer datatype without the sign");
Console.WriteLine("Min ushort: " + min_ushort);
Console.WriteLine("Max ushort: " + max_uhort + "\n");
// ushort від 0 до 65,535 (16 бітів, значення від 0 до 2^16 - 1)

int min_int = -2147483648;
int max_int = 2147483647;
Console.WriteLine("int is 32-bits integer datatype with the sign");
Console.WriteLine("Min int: " + min_int);
Console.WriteLine("Max int: " + max_int + "\n");
// int від -2,147,483,648 до 2,147,483,647 (32 біти, значення від - (2^32 / 2) до (2^32 / 2 - 1))

uint min_uint = 0;
uint max_uint = 4294967295;
Console.WriteLine("uint is 32-bits integer datatype without the sign");
Console.WriteLine("Min uint: " + min_uint);
Console.WriteLine("Max uint: " + max_uint + "\n");
// uint від 0 до 4,294,967,295 (32 біти, значення від 0 до 2^32 - 1)

Console.WriteLine("long is 64-bits integer datatype with the sign");
long min_long = -9223372036854775808;
long max_long = 9223372036854775807;
Console.WriteLine("Min long: " + min_long);
Console.WriteLine("Max long: " + max_long + "\n");
// long від -9,223,372,036,854,775,808 до 9,223,372,036,854,775,807 (64 біти, значення від - (2^64 / 2) до (2^64 / 2 - 1))

Console.WriteLine("ulong is 64-bits integer datatype without the sign");
ulong min_ulong = 0;
ulong max_ulong = 18446744073709551615;
Console.WriteLine("Min ulong: " + min_ulong);
Console.WriteLine("Max ulong: " + max_ulong + "\n");
// ulong від 0 до 18,446,744,073,709,551,615 (64 біти, значення від 0 до 2^64 - 1)

float float_var = (float)10 / 3;
double double_var = (double)10 / 3;
Console.WriteLine("float is 32-bits non-integer datatype with the accuracy to 7 significant digits");
Console.WriteLine("float: 10/3 = " + float_var);
Console.WriteLine("double is 64-bits non-integer datatype with the accuracy to 15-16 significant digits");
Console.WriteLine("double: 10/3 = " + double_var + "\n");

// різниця між float та double полягає у точності,
// розміру області значень та необхідній пам'яті
// (double надає більшу точність, має більшу область значень,
// але і потребує 64 біти, в той час як float - 32)

string str1 = "Some text";
string str2 = "Some text";
// Всі операції зміни string, такі як конкатенація,
// відбуваються шляхом створення нового об'єкта string,
// що може призводити до додаткових видатків пам'яті.

// string є особливим, оскільки він є reference type,
// але з деякими особливостями, які дозволяють йому
// вести себе подібно до value type у певних випадках.

// Компілятор C# автоматично оптимізує літеральні рядки,
// щоб вони використовували один і той же об'єкт в пам'яті,
// якщо вони мають однакове значення.
// Це називається "стрічковий пул" (string pool).

Console.WriteLine("If two string variables have same value, they will be equal as a value types (cause of string pool)");
Console.WriteLine("(str1 == str2) => " + (str1 == str2) + "\n");

string word = "word";
Console.WriteLine("Word before using it in the method: " + word);

void StringChanger(string stringToChange)
{
	Console.WriteLine("stringToChange before changes: " + stringToChange);
	stringToChange = stringToChange + " has been changed";
	Console.WriteLine("stringToChange after changes: " + stringToChange);
}
StringChanger(word);

Console.WriteLine("Word after using it in the method: " + word + "\n");
Console.WriteLine("While we trying to change a string, we are not changing it, we are actually creating a new one.");
Console.WriteLine("Thats why global string variable value doesnt change after we try to change it in the method");

Console.ReadKey();