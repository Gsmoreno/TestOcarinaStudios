import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import api from '../../services/Api';
import $ from 'jquery';
import './style.css';
import jwt from 'jwt-decode'
const LOGIN_URL = "Auth/Login";
function Login() {
    const navigate = useNavigate();
    async function handleClick(){
        var email = $("#email").val();
        var password = $("#senha").val();
        var name = "gustavo";
        var caloriesDay = "300";
        debugger;

        let axiosConfig = {
            headers: {
                'Content-Type': 'application/json;charset=UTF-8',
            }
        };

        var data =
        {
            name,
            email,
            password,
            caloriesDay
        }

        axios.post('https://localhost:5000/api/Auth/Login', data, axiosConfig)
            .then((response) => {
                console.log("sera?");
                const token = response.data;
                if (Object.keys(token).length !== 0) {
                    debugger;
                    localStorage.setItem('fastFlex-token', token);
                    navigate("/dashboard");
                } else {
                    localStorage.clear();
                    alert("Senha ou email incorretos!");
                }
            })
            .catch((error) => {
                // Captura do erro
                console.log(error.response.data);
            
                // Lógica de tratamento do erro
                // ...
            
                // Opcional: Manter na tela do Dashboard
                // ...
            
                // Exemplo de redirecionamento alternativo
                // window.location.href = '/dashboard';
              });

    }

    return (
        <>
            <div className="pageL">
                <form method="POST" className="formLogin">
                    <h1>Login</h1>
                    <p>Digite os seus dados de acesso no campo abaixo.</p>
                    <label >E-mail</label>
                    <input id='email' type="email" placeholder="Digite seu e-mail" />
                    <label >Senha</label>
                    <input id='senha' type="password" placeholder="Digite seu e-mail" />
                    <a href="/">Esqueci minha senha</a>
                    <button onClick={handleClick}>Entrar</button>
                </form>
            </div>
        </>
    );
}

export default Login;