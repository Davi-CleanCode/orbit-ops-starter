
import Link from 'next/link'

export default function Home() {
  return (
    <div className="min-h-screen bg-[#0D0D16] text-white flex flex-col items-center justify-center px-6">
      
      <h1 className="text-5xl font-bold mb-4 text-center">
        <span className="text-purple-500">Orbit</span> Ops
      </h1>

      <p className="text-gray-300 text-lg mb-10 text-center max-w-xl">
        Plataforma interna de desenvolvimento, CRM padrão e gestão integrada.
      </p>

      <div className="grid grid-cols-1 md:grid-cols-2 gap-6 w-full max-w-2xl">

        <a href="/login"
          className="bg-[#1A1A2E] hover:bg-[#24243a] p-6 rounded-xl shadow-md border border-purple-600/20 hover:border-purple-500 transition-all">
          <h2 className="text-xl font-semibold text-purple-400 mb-2">Login</h2>
          <p className="text-gray-400 text-sm">Acesse sua conta e inicie sua sessão.</p>
        </a>

        <a href="/dashboard"
          className="bg-[#1A1A2E] hover:bg-[#24243a] p-6 rounded-xl shadow-md border border-purple-600/20 hover:border-purple-500 transition-all">
          <h2 className="text-xl font-semibold text-purple-400 mb-2">Dashboard</h2>
          <p className="text-gray-400 text-sm">Visão geral da operação e indicadores.</p>
        </a>

        <a href="/leads"
          className="bg-[#1A1A2E] hover:bg-[#24243a] p-6 rounded-xl shadow-md border border-purple-600/20 hover:border-purple-500 transition-all">
          <h2 className="text-xl font-semibold text-purple-400 mb-2">Leads</h2>
          <p className="text-gray-400 text-sm">Gerencie contatos, informações e conversões.</p>
        </a>

        <a href="/projetos"
          className="bg-[#1A1A2E] hover:bg-[#24243a] p-6 rounded-xl shadow-md border border-purple-600/20 hover:border-purple-500 transition-all">
          <h2 className="text-xl font-semibold text-purple-400 mb-2">Projetos</h2>
          <p className="text-gray-400 text-sm">Organize tarefas, demandas e pipelines.</p>
        </a>

      </div>
    </div>
  );
}
