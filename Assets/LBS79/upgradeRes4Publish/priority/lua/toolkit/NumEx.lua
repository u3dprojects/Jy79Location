--- lua工具方法
do
  local int2Bio = NumEx2.int2Bio;
  local bio2Int = NumEx2.bio2Int;

  NumEx = {}
  function NumEx.stringToBool( s )
    return NumEx2.stringToBool( s );
  end
  function NumEx.stringToInt (s)
    return NumEx2.stringToInt (s);
  end
  function NumEx.int2Bio( n )
    if(n == nil) then return nil end;
    return int2Bio(n);
  end

  function NumEx.bio2Int( n )
    if(n == nil) then return 0 end;
    return bio2Int(n);
  end

  function NumEx.NextInt( min, max )
    return NumEx2.NextInt(min, max);
  end
  function NumEx.getB2Int( v )
    return NumEx2.getB2Int(v);
  end

  function NumEx.NextBool( ... )
    local orgs = {... }
    if(#orgs ==0) then
      return NumEx2.NextBool();
    elseif(#orgs == 1) then
      return NumEx2.NextBool(orgs[1]);
    end
    return NumEx2.NextBool();
  end

  --取一个数的整数部分
  function NumEx.getIntPart(x)
    local flag = 1;
    if(x < 0) then
      flag = -1;
    end
    x = math.abs(x);
    x = math.floor(x);
    return flag*x;
--    return x - x%1
  end

  return NumEx;

end;

module("NumEx",package.seeall)
