using AliCTTransformerPunc;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
        string applicationBase = AppDomain.CurrentDomain.BaseDirectory;
        string modelName = "alicttransformerpunc-zh-en-onnx";
        string modelFilePath = applicationBase + "./"+ modelName + "/model.int8.onnx";
        string configFilePath = applicationBase + "./" + modelName + "/punc.yaml";
        string tokensFilePath = applicationBase + "./" + modelName + "/tokens.txt";
        TimeSpan start_time1 = new TimeSpan(DateTime.Now.Ticks);
        AliCTTransformerPunc.CTTransformer ctTransformer = new CTTransformer(modelFilePath, configFilePath, tokensFilePath);
        TimeSpan end_time1 = new TimeSpan(DateTime.Now.Ticks);
        double elapsed_milliseconds1 = end_time1.TotalMilliseconds - start_time1.TotalMilliseconds;
        Console.WriteLine("load_model_elapsed_milliseconds:{0}", elapsed_milliseconds1.ToString());
        TimeSpan total_duration = new TimeSpan(0L);
        string orgtext = "As he watched the bird dipped again slanting his wings for the dive and then swinging them wildly and ineffectually as he followed the flying fish. The old man could see the slight bulge in the water that the big dolphin raised as they followed the escaping fish. The dolphin were cutting through the water below the flight of the fish and would be in the water, driving at speed, when the fish dropped. It is a big school of dolphin, he thought. They are widespread and the flying fish have little chance. The bird has no chance. The flying fish are too big for him and they go too fast. 他正看着，鸟儿又斜起翅膀准备俯冲，它向下冲来，然后又猛烈地扇动着双翼，追踪小飞鱼，但是没有成效。老人看见大海豚在追赶小飞鱼时海面微微隆起的水浪。海豚在飞掠的鱼下面破水而行，等鱼一落下，海豚就会飞速潜人水中。这群海豚真大呀！他想。它们分散开去，小飞鱼很少有机会逃脱。军舰鸟也没有机会，小飞鱼对它来说太大了，并且它们速度太快。";
        string text = "As he watched the bird dipped again slanting his wings for the dive and then swinging them wildly and ineffectually as he followed the flying fish The old man could see the slight bulge in the water that the big dolphin raised as they followed the escaping fish The dolphin were cutting through the water below the flight of the fish and would be in the water driving at speed when the fish dropped It is a big school of dolphin he thought They are widespread and the flying fish have little chance The bird has no chance The flying fish are too big for him and they go too fast 他正看着鸟儿又斜起翅膀准备俯冲它向下冲来然后又猛烈地扇动着双翼追踪小飞鱼但是没有成效老人看见大海豚在追赶小飞鱼时海面微微隆起的水浪海豚在飞掠的鱼下面破水而行等鱼一落下海豚就会飞速潜人水中这群海豚真大呀他想它们分散开去小飞鱼很少有机会逃脱军舰鸟也没有机会小飞鱼对它来说太大了并且它们速度太快";
        TimeSpan start_time = new TimeSpan(DateTime.Now.Ticks);
        string result = ctTransformer.GetResults(text:text,splitSize:15);
        Console.WriteLine("\r\n原文（Original text）：");
        Console.WriteLine(orgtext);
        Console.WriteLine("\r\n文本去标点（Text without punctuation）：");
        Console.WriteLine(text);
        Console.WriteLine("\r\n文本恢复标点（Text punctuation restoration）:");
        Console.WriteLine(result);
        Console.WriteLine("");
        TimeSpan end_time = new TimeSpan(DateTime.Now.Ticks);
        double elapsed_milliseconds = end_time.TotalMilliseconds - start_time.TotalMilliseconds;
        Console.WriteLine("elapsed_milliseconds:{0}", elapsed_milliseconds.ToString());
        Console.WriteLine("end!");
    }
}