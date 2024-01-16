import Navbar from "../Navbar/Navbar";
import Header from "../Header/Header";
import { Outlet } from "react-router-dom";

const RootLayout = () => {
  return (
    <>
      <Navbar />
      <Header />
      <Outlet />
    </>
  );
};

export default RootLayout;
