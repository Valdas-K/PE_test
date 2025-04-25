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
        <table cellPadding="5px">
            <thead>
                <tr>
                    <th>Pavadinimas</th>
                    <th>Galia Power</th>
                    <th>Temperatūra TFlow</th>
                    <th>Slėgis P01</th>
                    <th>Slėgis P02</th>
                </tr>
            </thead>
            <tbody>
                {realTimeStats.map((device, key) => (
                    <tr key={key}>
                        <td>
                            {device.title}
                        </td>
                        <td>
                            {device.power !== null ? device.power : '-'}

                        </td>
                        <td>
                            {device.tFlow !== null ? device.tFlow : '-'}

                        </td>
                        <td>
                            {device.p01 !== null ? device.p01 : '-'}

                        </td>
                        <td>
                            {device.p02 !== null ? device.p02 : '-'}
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
}