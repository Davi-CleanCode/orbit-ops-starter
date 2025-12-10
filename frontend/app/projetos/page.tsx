"use client";

import Link from "next/link";

// COMPONENTE INTERNO — sem criar arquivo separado
function ProjectCard({ project }: any) {
  return (
    <Link
      href={`/projetos/${project.id}`}
      className="border border-purple-600/20 bg-[#1A1A2E] hover:bg-[#24243a] p-4 rounded-xl 
                 shadow-md hover:shadow-lg transition block"
    >
      <h2 className="text-xl font-semibold text-purple-400">{project.name}</h2>

      <p className="text-gray-400 text-sm mt-1">
        Status: <span className="text-white">{project.status}</span>
      </p>

      <p className="text-gray-400 text-sm">
        Responsável: <span className="text-white">{project.owner}</span>
      </p>
    </Link>
  );
}

// MOCK — futuramente substituímos por banco real
const mockProjects = [
  { id: 1, name: "Monitoring System", status: "Em andamento", owner: "Davi" },
  { id: 2, name: "Pipeline CI/CD", status: "Concluído", owner: "DevOps Team" },
  { id: 3, name: "CRM Orbit", status: "Backlog", owner: "Orbit Ops" },
];

export default function Projetos() {
  return (
    <main className="min-h-screen text-white px-6 py-10 space-y-8">
      {/* Título + botão */}
      <div className="flex items-center justify-between">
        <h1 className="text-3xl font-bold">
          <span className="text-purple-500">Projetos</span>
        </h1>

        <Link
          href="/projetos/novo"
          className="bg-purple-600 hover:bg-purple-700 px-4 py-2 rounded-lg text-white font-medium transition"
        >
          ➕ Novo Projeto
        </Link>
      </div>

      {/* Grid de projetos */}
      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        {mockProjects.map((p) => (
          <ProjectCard key={p.id} project={p} />
        ))}
      </div>
    </main>
  );
}

/*
  Colocar uma extensão com IA para gerar um tipo de kanban com status do projeto e relatorio de avaçanço atraves de commits e automações atraves de trigs, grafico de distribuição de projetos por times devs
*/