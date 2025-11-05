
import Link from 'next/link'

export default function Home() {
  return (
    <div>
      <h1>Orbit Ops</h1>
      <p>Ambiente Interno de Desenvolvimento e CRM Padrão</p>
      <nav>
        <ul>
          <li><Link href='/login'>Login</Link></li>
          <li><Link href='/dashboard'>Dashboard</Link></li>
          <li><Link href='/leads'>Leads</Link></li>
          <li><Link href='/projetos'>Projetos</Link></li>
        </ul>
      </nav>
    </div>
  )
}
