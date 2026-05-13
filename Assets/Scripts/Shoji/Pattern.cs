using System.Collections.Generic;

public class ShojiPattern
{
    // ƒpƒ^[ƒ“
    public List<bool[,]> pattern { get; private set; } = new List<bool[,]>();

    /// <summary>
    /// ƒpƒ^[ƒ“‚Ì‰Šú‰»
    /// </summary>
    public void InitializePatterns()
    {
        // ‰¡‚R
        pattern.Add(new bool[,]
        {
        { true,  true,  true  }
        });
        
        // c‚R
        pattern.Add(new bool[,]
        {
            {true },
            {true }, 
            {true }
        });

        pattern.Add(new bool[,]
        {
            { false,  false,  true  },
            { false,  true,  false  },
            { true,  false,  false  }
        });

        pattern.Add(new bool[,]
        {
            { true,  false,  false  },
            { false,  true,  false  },
            { false,  false,  true  }
        });


    }
}
