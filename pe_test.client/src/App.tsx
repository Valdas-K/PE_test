import {
    createBrowserRouter,
    RouterProvider,
} from "react-router-dom";
import Home from "./pages/HomePage/Home";
import { Layout } from "./pages/Layout";
import HeatDevices from "./pages/HeatDevicesPage/HeatDevices";

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
                    path: 'heatdevices',
                    Component: HeatDevices
                }
            ]
        },
    ])

    return <RouterProvider router={router } />
}