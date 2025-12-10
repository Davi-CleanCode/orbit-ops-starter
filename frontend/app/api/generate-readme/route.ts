import { NextResponse } from "next/server";

export async function POST(req: Request) {
  const body = await req.json();

  const { name, owner, status, description } = body;

  // IA FAKE (temporária até você decidir usar OpenAI)
  const readme = `
# ${name}

**Responsável:** ${owner}  
**Status:** ${status}

---

## 📌 Descrição do Projeto
${description}

---

## 📁 Estrutura Recomendada
\`\`\`
/src
  /components
  /services
  /hooks
  /config
\`\`\`

---

## 🚀 Próximos Passos
- Configurar pipeline CI/CD
- Criar documentação adicional
- Definir ambiente DevOps (prod/dev)
`;

  return NextResponse.json({ readme });
}
