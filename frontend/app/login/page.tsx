
'use client'
import { useState } from 'react'

export default function Login() {
  const [username, setUsername] = useState('')
  const [password, setPassword] = useState('')

  const submit = async (e: any) => {
    e.preventDefault()
    alert('Login demo: funcionalidade de autenticação será integrada.')
  }

  return (
    <form onSubmit={submit}>
      <h2>Login</h2>
      <input value={username} onChange={(e)=>setUsername(e.target.value)} placeholder="username" />
      <input value={password} onChange={(e)=>setPassword(e.target.value)} placeholder="password" type="password" />
      <button type="submit">Entrar</button>
    </form>
  )
}
