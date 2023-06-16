import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './pages/Login/index';
import Cadastro from './pages/Cadastro/index';
import Dashboard from './pages/Dashboard/index';





function Routers() {
    return (
        <BrowserRouter>
                <Routes>                
                    <Route path="/" element={<Login />} />
                    <Route path="/dashboard" element={<Dashboard />} />
                    <Route path="/cadastro" element={<Cadastro />} />
                </Routes>
        </BrowserRouter>
    );
}
export default Routers;