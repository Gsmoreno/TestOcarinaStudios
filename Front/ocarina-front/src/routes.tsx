import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './pages/Login/index';
import Cadastro from './pages/Cadastro/index';
import Dashboard from './pages/Dashboard/index';
import Main from './pages/Main/index';




function Routers() {
    return (
        <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Login />} />
                    <Route path="/cadastro" element={<Cadastro />} />
                    <Route path="/main" element={<Main />} />
                    <Route path="/" element={<Dashboard />} />
                </Routes>
        </BrowserRouter>
    );
}
export default Routers;