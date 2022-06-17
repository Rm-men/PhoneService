import { Link, Outlet } from 'react-router-dom';
import LNavbar from './landing/LNavbar';

const Layout = () => {
    return (
        <>
        <LNavbar/>
        <Outlet></Outlet>
        </>
    )
}
export default Layout;