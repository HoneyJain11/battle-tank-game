using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    public TankView tankView;
    private void Start()
    {
        CreateTank();
    }
    private TankController CreateTank()
    {
        TankModel model = new TankModel(2, 100f);
        TankController tank = new TankController(model, tankView);
        return tank;
    }
}
