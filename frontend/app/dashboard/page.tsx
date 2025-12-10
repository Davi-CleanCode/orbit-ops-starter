export default function Dashboard() {
  return (
    <div className="min-h-screen text-white p-8">

      <h1 className="text-3xl font-bold mb-8">
        Dashboard · Orbit Ops
      </h1>

      {/* MÉTRICAS */}
      <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-10">
        <div className="bg-[#1A1A2E] p-6 rounded-xl">Total de Projetos — 0</div>
        <div className="bg-[#1A1A2E] p-6 rounded-xl">Deploys Hoje — 0</div>
        <div className="bg-[#1A1A2E] p-6 rounded-xl">Alerts — 0</div>
      </div>

      {/* HEADER DOS PROJETOS + BOTÃO */}
      <div className="flex items-center justify-between mb-4">
        <h2 className="text-2xl font-semibold text-purple-300">Projetos</h2>

        <a
          href="/projetos/novo"
          className="bg-purple-600 hover:bg-purple-700 px-4 py-2 rounded-lg font-semibold"
        >
          + Adicionar Projeto
        </a>
      </div>

      {/* LISTAGEM (placeholder) */}
      <div className="text-gray-400">Nenhum projeto ainda…</div>

    </div>
  );
}
