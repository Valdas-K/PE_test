import { useEffect, useState } from "react";
import { IHeatDevice } from "../../interfaces/IHeatDevice";
import { getApi} from "../../api";

export default function HeatDevices() {
    const [heatDevices, setHeatDevices] = useState<IHeatDevice[]>([])

    useEffect(() => {
        getApi<IHeatDevice[]>(`heatdevices`).then(s => s && setHeatDevices(s))
    }, [])

    return <div>
        <div className="text-3xl"> PANEVĖŽIO MIESTO ČŠT SISTEMOJE VYKSTANČIOS ŠILUMOS GAMYBOS DUOMENYS (REALIU LAIKU) </div>
        <div>
            {
                heatDevices.map(device => <div key={device.id}>{device.title} {device.power} {device.tflow} {device.p01} {device.p02}</div>)
            }
        </div>
    </div>
}