import { useEffect, useState } from "react";
import { IHeatDevice } from "../../interfaces/IHeatDevice";
import { getApi} from "../../api";

export default function HeatDevices() {
    const [lastDayStats, setLastDayStats] = useState<IHeatDevice[]>([])

    useEffect(() => {
        getApi<IHeatDevice[]>(`lastdaystats`).then(s => s && setLastDayStats(s))
    }, [])

    return <div>
        <div className="text-3xl"> PANEVĖŽIO MIESTO ČŠT SISTEMOS ŠILUMOS GAMYBOS DUOMENYS </div>
        <div>
            {
                lastDayStats.map(device => <div key={device.id}>{device.title} {device.power} </div>)
            }
        </div>
    </div>
}