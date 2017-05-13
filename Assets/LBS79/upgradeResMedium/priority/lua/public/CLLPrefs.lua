-- 本地存储
do
  local UserName = "UserName";
  local UserPsd = "UserPsd";
  local AutoFight = "AutoFight";
  local TestMode = "isTestMode";
  local TestMode = "isTestMode";
  local TestModeUrl = "TestModeUrl";
  local BuyCardTimes = "BuyCardTimes";
  Prefs = {};

  function Prefs.setUserName ( v )
    PlayerPrefs.SetString(UserName, v);
  end;
  function Prefs.getUserName (  )
    return PlayerPrefs.GetString(UserName, "");
  end;

  function Prefs.setUserPsd ( v )
    PlayerPrefs.SetString(UserPsd, v);
  end;
  function Prefs.getUserPsd ( ... )
    return PlayerPrefs.GetString(UserPsd, "");
  end;

  function Prefs.setAutoFight ( v )
    PlayerPrefs.SetInt(AutoFight, v and 0 or 1);
  end;
  function Prefs.getAutoFight ( ... )
    return (PlayerPrefs.GetInt(AutoFight, 0) == 0) and true or false;
  end;

  function Prefs.setTestMode( v )
    PlayerPrefs.SetInt(TestMode, v and 0 or 1);
  end;
  function Prefs.getTestMode( v )
    return (PlayerPrefs.GetInt(TestMode, 0) == 0) and true or false;
  end;

  function Prefs.setTestModeUrl ( v )
    PlayerPrefs.SetString(TestModeUrl, v);
  end;
  function Prefs.getTestModeUrl ( )
    return PlayerPrefs.GetString(TestModeUrl, "");
  end;

  -- 设置购买卡的次数
  function Prefs.setBuyCardTimes ( v )
    PlayerPrefs.SetInt(BuyCardTimes, v);
  end;

  -- 取得购买卡的次数
  function Prefs.getBuyCardTimes ( ... )
    return PlayerPrefs.GetInt(BuyCardTimes, 0);
  end;
end
module("CLLPrefs",package.seeall)
