using System;
using Newtonsoft.Json;

namespace Shoten13Sample;

public class AnchorInfo
{

  /// <summary>
  /// 空間アンカーの識別子
  /// </summary>
  public string anchorKey;

  /// <summary>
  /// 破棄される時間を文字列化にシリアライズしたもの
  /// dateTime.toString()で生成される想定
  /// </summary>
  public string expireOn;
}