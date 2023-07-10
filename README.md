# AliCTTransformerPunc
##### 简介：
项目中使用的Punc模型是阿里巴巴达摩院提供的Controllable Time-delay Transformer模型。
**项目基于Net 6.0，使用C#编写，调用Microsoft.ML.OnnxRuntime对onnx模型进行解码，支持跨平台编译。项目以库的形式进行调用，部署非常方便。**

##### 用途：
可用于语音识别模型输出文本的标点预测。

##### CTTransformerPunc模型结构：
Controllable Time-delay Transformer是达摩院语音团队提出的高效后处理框架中的标点模块。本项目为中文通用标点模型，模型可以被应用于文本类输入的标点预测，也可应用于语音识别结果的后处理步骤，协助语音识别模块输出具有可读性的文本结果。

![](https://www.modelscope.cn/api/v1/models/damo/punc_ct-transformer_zh-cn-common-vocab272727-pytorch/repo?Revision=master&FilePath=fig/struct.png&View=true)

Controllable Time-delay Transformer 模型结构如上图所示，由 Embedding、Encoder 和 Predictor 三部分组成。Embedding 是词向量叠加位置向量。Encoder可以采用不同的网络结构，例如self-attention，conformer，SAN-M等。Predictor 预测每个token后的标点类型。

在模型的选择上采用了性能优越的Transformer模型。Transformer模型在获得良好性能的同时，由于模型自身序列化输入等特性，会给系统带来较大时延。常规的Transformer可以看到未来的全部信息，导致标点会依赖很远的未来信息。这会给用户带来一种标点一直在变化刷新，长时间结果不固定的不良感受。基于这一问题，我们创新性的提出了可控时延的Transformer模型（Controllable Time-Delay Transformer, CT-Transformer），在模型性能无损失的情况下，有效控制标点的延时。

##### Punc常用参数（参考：punc.yaml文件）：
用于解码的punc.yaml配置参数，取自官方模型配置config.yaml原文件。

## 模型调用方法：

###### 1.添加项目引用
using AliCTTransformerPunc;

###### 2.模型初始化和配置
```csharp
string applicationBase = AppDomain.CurrentDomain.BaseDirectory;
string modelFilePath = applicationBase + "./punc_ct-transformer_zh-cn-common-vocab272727-pytorch/model.onnx";
string configFilePath = applicationBase + "./punc_ct-transformer_zh-cn-common-vocab272727-pytorch/punc.yaml";
string tokensFilePath = applicationBase + "./punc_ct-transformer_zh-cn-common-vocab272727-pytorch/tokens.txt";
AliCTTransformerPunc.CTTransformer ctTransformer = new CTTransformer(modelFilePath, configFilePath, tokensFilePath);
```
###### 3.调用
```csharp
string text = "跨境河流是养育沿岸人民的生命之源长期以来为帮助下游地区防灾减灾中方技术人员在上游地区极为恶劣的自然条件下克服巨大困难甚至冒着生命危险向印方提供汛期水文资料处理紧急事件中方重视印方在跨境河流问题上的关切愿意进一步完善双方联合工作机制凡是中方能做的我们都会去做而且会做得更好我请印度朋友们放心中国在上游的任何开发利用都会经过科学规划和论证兼顾上下游的利益";
string result = ctTransformer.GetResults(text);
```
###### 4.输出结果：
```
load_model_elapsed_milliseconds:979.125
跨境河流是养育沿岸人民的生命之源。长期以来，为帮助下游地区防灾减灾。中方技术人员在上游地区极为恶劣的自然条件下克服巨大困难，甚至冒着生命危险，向印方提供汛期水文资料处理紧急事件，中方重视印方在跨境河流问题上的关切，愿意进一步完善双方联合工作机制。凡是中方能做的，我们都会去做，而且会做得更好。我请印度朋友们放心中国在上游的任何开发利用，都会经过科学规划和论证，兼顾上下游的利益。
elapsed_milliseconds:381.6953125
end!
```

其他说明：
测试用例：AliCTTransformerPunc.Examples。
测试环境：windows11。

通过以下链接了解更多：
https://www.modelscope.cn/models/damo/punc_ct-transformer_zh-cn-common-vocab272727-pytorch/summary
