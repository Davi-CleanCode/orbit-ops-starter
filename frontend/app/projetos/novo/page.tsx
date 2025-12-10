"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";

export default function NovoProjeto() {
  const router = useRouter();

  const [form, setForm] = useState({
    name: "",
    owner: "",
    status: "Backlog",
    description: "",
  });

  function handleChange(e: any) {
    setForm({ ...form, [e.target.name]: e.target.value });
  }

  function handleSubmit(e: any) {
    e.preventDefault();

    // FUTURO: salvar em banco, gerar README, pipeline etc.
    console.log("Novo projeto criado:", form);

    // Redirecionar
    router.push("/projetos");
  }

  return (
    <main className="min-h-screen px-6 py-10 text-white bg-[#0D0D16]">
      <div className="max-w-2xl mx-auto bg-[#1A1A2E] border border-purple-600/20 p-8 rounded-2xl shadow-xl">
        
        <h1 className="text-3xl font-bold text-purple-400 mb-6">
          Criar Novo Projeto
        </h1>

        <form onSubmit={handleSubmit} className="space-y-6">

          {/* Nome do projeto */}
          <div>
            <label className="block text-gray-300 font-medium mb-1">
              Nome do Projeto
            </label>
            <input
              type="text"
              name="name"
              required
              value={form.name}
              onChange={handleChange}
              className="w-full p-3 rounded-lg bg-[#0D0D16] border border-purple-600/30 
                         focus:border-purple-500 focus:ring-1 focus:ring-purple-500 outline-none"
            />
          </div>

          {/* Responsável */}
          <div>
            <label className="block text-gray-300 font-medium mb-1">
              Responsável
            </label>
            <input
              type="text"
              name="owner"
              required
              value={form.owner}
              onChange={handleChange}
              className="w-full p-3 rounded-lg bg-[#0D0D16] border border-purple-600/30 
                         focus:border-purple-500 focus:ring-1 focus:ring-purple-500 outline-none"
            />
          </div>

          {/* Status */}
          <div>
            <label className="block text-gray-300 font-medium mb-1">
              Status Atual
            </label>
            <select
              name="status"
              value={form.status}
              onChange={handleChange}
              className="w-full p-3 rounded-lg bg-[#0D0D16] border border-purple-600/30 
                         focus:border-purple-500 focus:ring-1 focus:ring-purple-500 outline-none"
            >
              <option value="Backlog">Backlog</option>
              <option value="Em andamento">Em andamento</option>
              <option value="Concluído">Concluído</option>
              <option value="Pausado">Pausado</option>
            </select>
          </div>

          {/* Descrição */}
          <div>
            <label className="block text-gray-300 font-medium mb-1">
              Descrição
            </label>
            <textarea
              name="description"
              rows={4}
              value={form.description}
              onChange={handleChange}
              className="w-full p-3 rounded-lg bg-[#0D0D16] border border-purple-600/30 
                         focus:border-purple-500 focus:ring-1 focus:ring-purple-500 outline-none"
            ></textarea>
          </div>

          {/* Botões */}
          <div className="flex justify-between pt-4">
            <button
              type="button"
              onClick={() => router.push("/projetos")}
              className="px-4 py-2 bg-gray-600/50 hover:bg-gray-600 text-white rounded-lg transition"
            >
              Voltar
            </button>

            <button
              type="submit"
              className="px-6 py-2 bg-purple-600 hover:bg-purple-700 text-white rounded-lg font-semibold transition"
            >
              Criar Projeto
            </button>
          </div>
        </form>
      </div>
    </main>
  );
}
