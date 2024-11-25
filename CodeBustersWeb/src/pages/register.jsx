import React, { useState } from 'react'
import { Navigate, Link, useNavigate } from 'react-router-dom'
import { useAuth } from './authContext'
import { doCreateUserWithEmailAndPassword } from '../scripts/auth'
import Header from '../components/Header';

const Register = () => {

    const navigate = useNavigate()

    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [confirmPassword, setconfirmPassword] = useState('')
    const [isRegistering, setIsRegistering] = useState(false)
    const [errorMessage, setErrorMessage] = useState('')

    const { userLoggedIn } = useAuth()

    const onSubmit = async (e) => {
        e.preventDefault()
        if (!isRegistering) {
            setIsRegistering(true)
            await doCreateUserWithEmailAndPassword(email, password)
        }
    }

    return (
        <div>
            <Header />
            {userLoggedIn && (<Navigate to={'/'} replace={true} />)}
            <div className="FormContainer">
                <div className="LogInBox">
                    <div className="LoginTitle">
                        <h3> Create a new account </h3>
                    </div>
                    <form onSubmit={onSubmit}
                        className="Sform">
                        <div>
                            <label className="FLabel">
                                Email
                            </label><br />
                            <input className="Finput"
                                type="email"
                                autoComplete="email"
                                required
                                value={email} onChange={(e) => { setEmail(e.target.value) }}
                            />
                        </div>
                        <br />
                        <div>
                            <label className="FLabel">
                                Password
                            </label> <br />
                            <input className="Finput"
                                disabled={isRegistering}
                                type="password"
                                autoComplete="current-password"
                                required
                                value={password} onChange={(e) => { setPassword(e.target.value) }}
                            />
                        </div> <br />
                        <div>
                            <label className="FLabel">
                                Confirm Password
                            </label> <br />
                            <input className="Finput"
                                disabled={isRegistering}
                                type="password"
                                autoComplete="off"
                                required
                                value={confirmPassword} onChange={(e) => { setconfirmPassword(e.target.value) }}
                            />
                        </div> <br />

                        {errorMessage && (
                            <span className='FError'>{errorMessage}</span>
                        )}

                        <button
                            type="submit"
                            disabled={isRegistering}
                            className={`FButtonS1 ${isRegistering ? 'FSinButton2' : 'FSinButton'}`}
                        >
                            {isRegistering ? 'Signing Up...' : 'Sign Up'}
                        </button>
                    </form>
                    <div className='FDivider'>
                        <div className='FLine'></div><div className='FLabel'>OR</div><div className='FLine'></div>
                    </div>
                    <p className="Fsubtext">Already have an account? <Link to={'/login'} className="Flink"> Sign in</Link></p>

                </div>
            </div>
        </div>
    )
}

export default Register