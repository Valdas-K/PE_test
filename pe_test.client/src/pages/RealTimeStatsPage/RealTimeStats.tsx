import { useEffect, useState } from "react";
import { IHeatDevice } from "../../interfaces/IHeatDevice";
import { getApi} from "../../api";

export default function RealTimeStats() {
    const [realTimeStats, setRealTimeStats] = useState<IHeatDevice[]>([])

    useEffect(() => {
        getApi<IHeatDevice[]>(`realtimestats`).then(s => s && setRealTimeStats(s))
    }, [])

    return <div>
        <div className="text-3xl"> PANEVĖŽIO MIESTO ČŠT SISTEMOJE VYKSTANČIOS ŠILUMOS GAMYBOS DUOMENYS (REALIU LAIKU) </div>
        <div>
            {
                realTimeStats.map(device => <div key={device.id}> {device.title} {device.power} {device.tFlow} {device.p01} {device.p02}</div>)
            }
        </div>
    </div>
}