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
        <table cellPadding="5px">
            <thead>
                <tr>
                    <th>Pavadinimas</th>
                    <th>Energija Volume</th>
                </tr>
            </thead>
            <tbody>
                {lastDayStats.map((device, key) => (
                    <tr key={key}>
                        <td>
                            {device.title}
                        </td>
                        <td>
                            {device.volume !== null ? device.volume : '-' }
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
}