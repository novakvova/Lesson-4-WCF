using System;

// Служба УРОВНЯ ВЫЗОВА должна быть с КОНТРОЛЕМ СОСТОЯНИЯ (state-aware).
// Состояние службы бывает ВЫСОКОЗАТРАТНЫМ, поэтому 
// экземпляр службы требуется уничтожать после каждого вызова!

namespace Service
{
    //высокозатратный объект
    class State
    {
        int[] array = new int[1000000]; //4 мегайбайта

        public State()
        {
            for (int i = 0; i < 1000000; i++)            
                array[i] = i;            
        }

        public string GetState()
        {
            return array.Length.ToString();
        }
    }
}
