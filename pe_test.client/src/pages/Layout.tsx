import { Link, Outlet, useFetchers, useNavigation } from "react-router-dom";

export function Layout() {
    const navigation = useNavigation();
    const fetchers = useFetchers();
    const fetcherInProgress = fetchers.some((f) => ["loading", "submitting"].includes(f.state));

    return <div className='container mx-auto flex flex-col gap-y-2'>
        <header className='bg-amber-700 text-white p-1'>
            <div className='text-3xl'>Panevėžio energija</div>
            <nav>
                <ul className='flex gap-x-2'>
                    <li><Link to="/">Pagrindinis</Link></li>
                    <li><Link to="/realtimestats">Statistika realiu laiku</Link></li>
                    <li><Link to="/lastdaystats">Paskutinės dienos statistika</Link></li>
                </ul>
            </nav>
        </header>
        <div>
            {navigation.state !== "idle" && <div className="m-1">Navigation in progress...</div>}
            {fetcherInProgress && <div className="m-1">Fetcher in progress...</div>}
        </div>
        <Outlet />
        <footer className='bg-gray-500 text-white text-sm flex content-center justify-center items-center h-10'>
            <div> Panevėžio energija </div>
        </footer>
    </div>
}