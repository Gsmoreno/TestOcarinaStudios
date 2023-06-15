import axios from 'axios';
import { useNavigate } from 'react-router-dom';

import $ from 'jquery';
import './style.css';

function Login() {
    const navigate = useNavigate();
    const HandleClick = async () => {
        var Email = $("#email").val();
        var Senha = $("#senha").val();

        await axios({
            method: 'post',
            url: 'https://localhost:44367/api/Auth/Login',
            data: {
                email: Email,
                senha: Senha
            }
        }).then(function (response) {
            const token = response.data;
            if (Object.keys(token).length !== 0) {
                localStorage.setItem('fastFlex-token', token);
                navigate("/dashboard");

            } else {
                localStorage.clear();
                alert("Senha ou email incorretos!")
            }
        });
    }
    return (
        <>
            <div className="page">
                <form method="POST" className="formLogin">
                    <h1>Login</h1>
                    <p>Digite os seus dados de acesso no campo abaixo.</p>
                    <label >E-mail</label>
                    <input type="email" placeholder="Digite seu e-mail"  />
                    <label >Senha</label>
                    <input type="password" placeholder="Digite seu e-mail" />
                    <a href="/">Esqueci minha senha</a>
                    <input type="submit" value="Acessar" className="btn" />
                </form>
            </div>
        </>
    );
}

export default Login;