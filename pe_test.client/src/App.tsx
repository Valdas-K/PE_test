import {
    createBrowserRouter,
    RouterProvider,
} from "react-router-dom";
import Home from "./pages/HomePage/Home";
import { Layout } from "./pages/Layout";
import RealTimeStats from "./pages/RealTimeStatsPage/RealTimeStats";
import LastDayStats from "./pages/LastDayStatsPage/LastDayStats";

export default function App() {
    const router = createBrowserRouter([
        {
            path: "/",
            Component: Layout,
            children: [
                {
                    index: true,
                    Component: Home
                },
                {
                    path: 'realtimestats',
                    Component: RealTimeStats
                },
                {
                    path: 'lastdaystats',
                    Component: LastDayStats
                }
            ]
        },
    ])

    return <RouterProvider router={ router } />
}