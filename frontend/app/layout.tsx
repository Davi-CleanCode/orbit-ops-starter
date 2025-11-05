
import './globals.css'
export const metadata = {
  title: 'Orbit Ops',
  description: 'Orbit internal CRM and DevOps hub',
}

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="pt-BR">
      <body>
        <main style={{ padding: 24, fontFamily: 'Inter, system-ui, sans-serif' }}>
          {children}
        </main>
      </body>
    </html>
  )
}
